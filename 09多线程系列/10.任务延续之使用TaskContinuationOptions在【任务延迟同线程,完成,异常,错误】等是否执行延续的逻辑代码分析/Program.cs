using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace _10.任务延续之使用TaskContinuationOptions在_任务延迟同线程_完成_异常_错误_等是否执行延续的逻辑代码分析
{
    class Program
    {
        static void Main(string[] args)
        {

            ////此时是,task1执行完成后,再执行task2,task2执行完成后,再执行task3, 形成一个串行效果
            //Task task1 = new Task(() =>
            //  {
            //      Thread.Sleep(3000);
            //      Console.WriteLine("task1 tid={0},dt={1}",Thread.CurrentThread.ManagedThreadId,DateTime.Now);
            //  });
            //Task task2 = task1.ContinueWith((t) =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("task2 tid={0},dt={1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            //});
            //Task task3 = task2.ContinueWith((t) =>
            //{
            //    Console.WriteLine("task3 tid={0},dt={1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            //});

            //task1.Start();

            //Console.Read();





            ////在添加了CancellationTokenSource后, task2被取消了,但什么时候被取消的,?
            ////此时task1和task2的延续任务task3 并行执行?  没有形成一个延续的效果, 因为此时就算task2被取消了,也应该是task1执行完,再执行task3.
            ////向应该被取消的 System.Threading.CancellationToken 发送信号  如何发送信号呢?
            //CancellationTokenSource source = new CancellationTokenSource();//判断任务的延续
            //source.Cancel();//传到取消请求?
            //Task task1 = new Task(() =>
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine("task1 tid={0},dt={1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            //});
            //Task task2 = task1.ContinueWith((t) =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("task2 tid={0},dt={1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            //}, source.Token);//此时task1 的延续任务task2是不会执行的
            //Task task3 = task2.ContinueWith((t) =>
            //{
            //      Console.WriteLine("task3 tid={0},dt={1},task2的转态:{2}", Thread.CurrentThread.ManagedThreadId, DateTime.Now,task2.Status);
            //});

            //task1.Start();

            //Console.Read();





            ////在添加了CancellationTokenSource后, task2被取消了,但什么时候被取消的,?
            ////此时task1和task2的延续任务task3 并行执行?  没有形成一个延续的效果, 因为此时就算task2被取消了,也应该是task1执行完,再执行task3.
            ////怎么办呢? 用TaskContinuationOptions.LazyCancellation 在延续取消的情况下，防止延续的完成直到完成先前的任务。
            ////也就是task1的执行和判断task2的取消是并行执行的, 所以叫预判断. 此时就存在判断提前于task1的执行前完成,造成task1和task2并行执行.
            ////向应该被取消的 System.Threading.CancellationToken 发送信号  如何发送信号呢?
            //CancellationTokenSource source = new CancellationTokenSource();//判断任务的延续
            //source.Cancel();//传到取消请求?
            //Task task1 = new Task(() =>
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine("task1 tid={0},dt={1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            //});
            //Task task2 = task1.ContinueWith((t) =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("task2 tid={0},dt={1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            //}, source.Token,TaskContinuationOptions.LazyCancellation,TaskScheduler.Current);//此时task1 的延续任务task2是不会执行的
            //Task task3 = task2.ContinueWith((t) =>
            //{
            //     Console.WriteLine("task3 tid={0},dt={1},task2的转态:{2}", Thread.CurrentThread.ManagedThreadId, DateTime.Now,task2.Status);
            //});

            //task1.Start();

            //Console.Read();







            ////task1和task2同步执行,线程id是一样的
            //Task task1 = new Task(() =>
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine("task1 tid={0},dt={1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            //});
            //Task task2 = task1.ContinueWith((t) =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("task2 tid={0},dt={1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            //},TaskContinuationOptions.ExecuteSynchronously);
            //Task task3 = task2.ContinueWith((t) =>
            //{
            //    Console.WriteLine("task3 tid={0},dt={1},task2的转态:{2}", Thread.CurrentThread.ManagedThreadId, DateTime.Now,task2.Status);
            //});

            //task1.Start();

            //Console.Read();


            Task task1 = new Task(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("task1 tid={0},dt={1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
                throw new Exception("helle");
            });
            Task task2 = task1.ContinueWith((t) =>
            {
                //Thread.Sleep(100);
                Console.WriteLine("task2 tid={0},dt={1},task1的转态:{2}", Thread.CurrentThread.ManagedThreadId, DateTime.Now, task1.Status);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task task3 = task2.ContinueWith((t) =>
            {
                Console.WriteLine("task3 tid={0},dt={1},task2的转态:{2}", Thread.CurrentThread.ManagedThreadId, DateTime.Now, task2.Status);
            });

            task1.Start();

            Console.Read();


        }
    }
}
