using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02.Thread实例方法介绍之生命周期管理的Start_Suspend_Resume_Join_Interrupt_Abort五大方法介绍
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主线程开始执行");
            Thread thread = new Thread(new ThreadStart(() =>
            {
                Console.WriteLine("子线程正在执行");
                Thread.Sleep(2000);
                Console.WriteLine("子线程完成");
            }));
            thread.Start();
            thread.Join();//调用线程等待子线程执行完成才执行,[在此处等待子线程执行完成],也就是阻塞主线程.
            Console.WriteLine("主线程继续执行");
            Thread.Sleep(1000);
            Console.WriteLine("主线程执行完成");
            Console.Read();
        }
    }
}
