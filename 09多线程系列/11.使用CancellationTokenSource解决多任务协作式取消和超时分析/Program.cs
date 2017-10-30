using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace _11.使用CancellationTokenSource解决多任务协作式取消和超时分析
{
    class Program
    {
        static void Main(string[] args)
        {

            ////取消到底什么怎样的一个流程呢?  关键点在哪里?如何取消呢?如何传递信号呢? 基本概况是啥呢?有东西在执行,取消正在执行的东西?如何体现一直运行? 如何体现判断取消?
            ////之前可以一看到就懵逼了(没概念+更加没分析.),无论什么都是要有个模型的? 比如理解模型? 思考模型? 对比模型? 等等
            //var isStop = false;
            //var thread = new Thread(() =>
            //  {
            //      while(!isStop) //为何要有while呢? 如何感知变化? isStop为false时一直运行.
            //      {
            //          Thread.Sleep(100);// 比如间断输出在控制台上, 也会困在这里  那就换,那就分析
            //          //有可能会困在正在运行 这件事上,  其实很多事都是很简单的,只是理解有问题. 那就换,那就分析
            //          Console.WriteLine("当前thread={0} 正在运行", Thread.CurrentThread.ManagedThreadId);

            //      }
            //  });
            //thread.Start();
            //Thread.Sleep(1000);
            //isStop = true;
            //Console.Read();




            //CancellationTokenSource source = new CancellationTokenSource();
            //var task = Task.Factory.StartNew(() =>
            //{
            //    //为何要有while呢? 如何感知变化?
            //    while (!source.IsCancellationRequested) //判断取消是否已经请求?source.IsCancellationRequested为false时一直运行
            //    {
            //        Thread.Sleep(100);// 比如间断输出在控制台上, 也会困在这里  那就换,那就分析
            //                          //有可能会困在正在运行 这件事上,  其实很多事都是很简单的,只是理解有问题. 那就换,那就分析
            //        Console.WriteLine("当前thread={0} 正在运行", Thread.CurrentThread.ManagedThreadId);

            //    }
            //});

            //Thread.Sleep(1000);
            //source.Cancel();
            //Console.Read();




            //CancellationTokenSource source = new CancellationTokenSource();
            //source.Token.Register(() =>
            //{
            //    Thread.Sleep(100);
            //    //如果当前的token被取消,此函数将会被执行..
            //    Console.WriteLine("当前的的source已经被取消,现在可以做资源清理工作了....");
            //});//register的执行和 while判断同时执行.? 是这样的吗?
            //var task = Task.Factory.StartNew(() =>
            //{
            //    //为何要有while呢? 如何感知变化?
            //    while (!source.IsCancellationRequested) //判断取消是否已经请求?source.IsCancellationRequested为false时一直运行
            //    {
            //        Thread.Sleep(100);// 比如间断输出在控制台上, 也会困在这里  那就换,那就分析
            //                          //有可能会困在正在运行 这件事上,  其实很多事都是很简单的,只是理解有问题. 那就换,那就分析
            //        Console.WriteLine("当前thread={0} 正在运行", Thread.CurrentThread.ManagedThreadId);

            //    }
            //});

            //Thread.Sleep(1000);
            //source.Cancel();
            //Console.Read();



            //CancellationTokenSource source = new CancellationTokenSource(100);
            //source.Token.Register(() =>
            //{
            //    Thread.Sleep(100);
            //    //如果当前的token被取消,此函数将会被执行..
            //    Console.WriteLine("当前的的source已经被取消,现在可以做资源清理工作了....");
            //});//register的执行和 while判断同时执行.? 是这样的吗?
            //var task = Task.Factory.StartNew(() =>
            //{
            //    //为何要有while呢? 如何感知变化?
            //    while (!source.IsCancellationRequested) //判断取消是否已经请求?source.IsCancellationRequested为false时一直运行
            //    {
            //        Thread.Sleep(100);// 比如间断输出在控制台上, 也会困在这里  那就换,那就分析
            //                          //有可能会困在正在运行 这件事上,  其实很多事都是很简单的,只是理解有问题. 那就换,那就分析
            //        Console.WriteLine("当前thread={0} 正在运行", Thread.CurrentThread.ManagedThreadId);

            //    }
            //});

            //source.CancelAfter(new TimeSpan(0, 0, 0, 1));
            //Console.Read();




            CancellationTokenSource source1 = new CancellationTokenSource();
            source1.Cancel();
            CancellationTokenSource source2 = new CancellationTokenSource();
            CancellationTokenSource source3 = CancellationTokenSource.CreateLinkedTokenSource(source1.Token,source2.Token);

            Console.WriteLine("source1:{0},Source2:{1},source3:{2}",source1.IsCancellationRequested,source2.IsCancellationRequested,source3.IsCancellationRequested);
            Console.Read();
        }
    }
}
