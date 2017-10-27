using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _05.从windbg角度理解ThreadPool和Thread的差异以及对工作线程和IO线程的工作差异分析
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadPool.QueueUserWorkItem((obj) => {
            //    Console.WriteLine("我是工作线程:{0},context:{1}",Thread.CurrentThread.ManagedThreadId,obj);
            //},"HelloWorld");
            //Console.WriteLine("主线程:{0}",Thread.CurrentThread.ManagedThreadId);
            //Console.Read();


            //ThreadPool.QueueUserWorkItem((obj) => {
            //    var func = obj as Func<string>;
            //    Console.WriteLine("我是工作线程:{0},context:{1}", Thread.CurrentThread.ManagedThreadId, func());
            //}, new Func<string>(()=> { return "HelloWorld"; }));
            //Console.WriteLine("主线程:{0}", Thread.CurrentThread.ManagedThreadId);
            //Console.Read();

            //for (int i = 0; i < 10; i++)
            //{
            //    Thread thread = new Thread(() => {
            //        for (int j = 0; j < 10; j++)
            //        {
            //            Console.WriteLine("work:{0},tid:{1}",i,Thread.CurrentThread.m);
            //        }
            //    });
            //    thread.Name = "main" + i;
            //    thread.Start();
            //}
            //Console.Read();




            for (int i = 0; i < 10; i++)
            {

                ThreadPool.QueueUserWorkItem((obj) => {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.WriteLine("work:{0},tid:{1}", i, Thread.CurrentThread.ManagedThreadId);
                    }
                });

                //此时不可以设置线程名称,此时线程是租用的,不是专有的,专有的话我们可以做各种操作.线程池的线程不属于你,你只是租用而已
                //thread.Name = "main" + i;
                //thread.Start();
            }
            Console.Read();
        }
    }
}
