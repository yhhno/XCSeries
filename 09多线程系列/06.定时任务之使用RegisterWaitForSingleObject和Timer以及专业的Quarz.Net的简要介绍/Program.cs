using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _06.定时任务之使用RegisterWaitForSingleObject和Timer以及专业的Quarz.Net的简要介绍
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("main time:{0}", DateTime.Now);
            //ThreadPool.RegisterWaitForSingleObject(new AutoResetEvent(false), new WaitOrTimerCallback((obj, b) => {

            //    ////做逻辑判断，判断是否在否以时刻执行。。。
            //    Console.WriteLine("obj:{0},tid:{1},time:{2}", obj, Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            //}), "helloworld", 1000, false);


            //Console.Read();



            Timer timer = new Timer(new TimerCallback((obj) => {
                ////做逻辑判断，判断是否在否以时刻执行。。。
                Console.WriteLine("obj:{0},tid:{1},time:{2}", obj, Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            }), "HelloWorld", 1000, 1000);

           
           

            Console.Read();
        }
    }
}
