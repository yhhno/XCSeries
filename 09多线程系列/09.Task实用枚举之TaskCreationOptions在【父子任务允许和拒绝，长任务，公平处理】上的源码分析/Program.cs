using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _09.Task实用枚举之TaskCreationOptions在_父子任务允许和拒绝_长任务_公平处理_上的源码分析
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task task = new Task(() =>
            //  {

            //      Task task1 = new Task(() =>
            //      {
            //          Thread.Sleep(1000);
            //          Console.WriteLine("Task1");
            //      },TaskCreationOptions.AttachedToParent);
            //      task1.Start();
            //      Task task2 = new Task(() =>
            //      {
            //          Thread.Sleep(1000);
            //          Console.WriteLine("Task2");
            //      }, TaskCreationOptions.AttachedToParent);
            //      task2.Start();

            //  });
            //task.Start();
            ////如果没加TaskCreationOptions.AttachedToParent的话,
            ////task的执行是这样的,task1和task2都启动了,就算是task的任务执行了,此时就不阻塞主线程了,
            ////加了的话,task是task1和task2的父任务,父任务要想执行完成,必须等子任务执行完毕,才算完成.有task的延续任务才能执行延续任务,没有的话,就不阻塞主线程的执行.
            ////这样有什么好处? 和Waitall有什么区别? 和whenall有什么区别呢?
            //task.Wait();//相当于实现waitall的操作, 
            //Console.WriteLine("我是主线程");
            //Console.Read();





            //Task task = new Task(() =>
            //{

            //    Task task1 = new Task(() =>
            //    {
            //        Thread.Sleep(1000);
            //        Console.WriteLine("Task1");
            //    }, TaskCreationOptions.AttachedToParent);
            //    task1.Start();
            //    Task task2 = new Task(() =>
            //    {
            //        Thread.Sleep(1000);
            //        Console.WriteLine("Task2");
            //    }, TaskCreationOptions.AttachedToParent);
            //    task2.Start();

            //},TaskCreationOptions.DenyChildAttach);//子添加,父拒绝.  子任务还是独立执行
            //task.Start();
            ////如果没加TaskCreationOptions.AttachedToParent的话,
            ////task的执行是这样的,task1和task2都启动了,就算是task的任务执行了,此时就不阻塞主线程了,
            ////加了的话,task是task1和task2的父任务,父任务要想执行完成,必须等子任务执行完毕,才算完成.有task的延续任务才能执行延续任务,没有的话,就不阻塞主线程的执行.
            ////这样有什么好处? 和Waitall有什么区别? 和whenall有什么区别呢?
            //task.Wait();//此时没有实现waitall的操作,  只能等待父任务task
            //Console.WriteLine("我是主线程");
            //Console.Read();






            Task task = new Task(() =>
            {
                    Thread.Sleep(1000);
                    Console.WriteLine("Task1");

            }, TaskCreationOptions.LongRunning|TaskCreationOptions.AttachedToParent);
            task.Start();
         
            task.Wait();
            Console.WriteLine("我是主线程");
            Console.Read();
        }
    }
}
