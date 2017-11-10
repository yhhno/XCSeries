using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _22.混合模式锁之对ManualResetEventSlim_SemaphoreSlim_中的原理知识分析
{
    class Program
    {
        static ManualResetEventSlim slim = new ManualResetEventSlim(); //此时是合围转态,不可通过.                                                                  
       static SemaphoreSlim sslim = new SemaphoreSlim(1, 10); //默认1个线程同时运行，最大10个



        //static void Main(string[] args)
        //{

        //    Task task = new Task(() =>
        //      {
        //          Run();
        //      });
        //    task.Start();
        //    Thread.Sleep(1000*3);
        //    //能组合出什么样的特性
        //    slim.Set();//如何释放也是个问题? 释放过程没逻辑推理过.  是由谁来释放?
        //    Console.Read();
        //}
        //static  void Run()
        //{
        //    slim.Wait(); //是由谁来阻止?

        //    Console.WriteLine("我执行了");
        //}







        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() =>
                {
                    Run();
                });
            }

            //某一个时刻，我像改变默认的并行线程个数，从默认的1 改成10
            //能组合出什么样的特性? 前两秒逐个执行,2秒后全部执行.
            System.Threading.Thread.Sleep(2000);
            sslim.Release(10);

            Console.Read();
        }

        static void Run()
        {
            sslim.Wait();

            Thread.Sleep(1000 * 1);

            Console.WriteLine("当前t1={0} 正在运行 {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);

            sslim.Release();
        }
    }
}

