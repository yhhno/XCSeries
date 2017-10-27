using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _07.Task和Task_T_之启动任务的三大方式Run_RunSynchronously_Start_StartNew以及内部代码异同点解析
{
    class Program
    {
        static void Main(string[] args)
        {
            ////实例化方式启动 异步方法
            //Task task = new Task(() =>
            //{
            //    Console.WriteLine("我是工作线程:tid={0}", Thread.CurrentThread.ManagedThreadId);
            //});
            //task.Start();


            //Task.Factory方式启动,类似于ThreadPool  异步方法
            //var task = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("我是工作线程:tid={0}", Thread.CurrentThread.ManagedThreadId);
            //});

            ////Task.Run方式启动   异步方法
            //var task = Task.Run(() =>
            //{
            //    Console.WriteLine("我是工作线程:tid={0}", Thread.CurrentThread.ManagedThreadId);
            //});


            ////Task的启动,,同步方法,也就是阻塞  什么是同步执行呢? a方法执行完,才能执行b方法. 大家是同步的
            //Task task = new Task(() =>
            //{
            //    Console.WriteLine("我是工作线程:tid={0}", Thread.CurrentThread.ManagedThreadId);
            //});
            //task.RunSynchronously();


            //Task<TResult>
            var task = new Task<string>(() =>
            {
                return "Helloworld";
            });
            task.Start();
            var msg = task.Result;

            Console.WriteLine(msg);


            Console.Read();
        }
    }
}
