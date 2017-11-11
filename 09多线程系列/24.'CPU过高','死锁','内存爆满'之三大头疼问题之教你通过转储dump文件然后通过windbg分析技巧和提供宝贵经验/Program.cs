using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _24._CPU过高___死锁___内存爆满_之三大头疼问题之教你通过转储dump文件然后通过windbg分析技巧和提供宝贵经验
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            //Run();

            //new Program().Run();

            for (int i = 0; i < 10000000; i++)
            {
                sb.Append("HelloWorld");
            }

            Console.Read();
        }


        ////cpu过高
        //static void Run()
        //{
        //    //此时task长久被cpu占用,因为cpu一直要这个操作?
        //    var task = Task.Factory.StartNew(() =>
        //    {
        //        var i = true;
        //        //这个地方是一个非常复杂的逻辑,导致死循环.
        //        while (true)
        //        {
        //            i = !i;
        //        }
        //    });
        //}

        ////死锁
        //   void Run()
        //{
        //    //使用lock,引用下当前类
        //    lock (this)//这里锁住了当前类,通过同步块实现的
        //    {
        //        var task = Task.Run(() =>
        //        {
        //            Console.WriteLine("-----Start------");
        //            Thread.Sleep(1000);
                    
        //            Run2();//假死状态.Run2中,要获取当前类的锁, 但此时锁还没有释放(task执行完才会释放.).获取不到.,
        //            Console.WriteLine("-----End------");
        //        });//Task 执行完后,释放lock锁

        //        task.Wait();//加上这句,防止lock先退出,  为什么会先退出呢? task的大前提是什么? 异步呀? thread的大前提也是异步
        //    }
        //}

        // void Run2()
        //{
        //    lock (this)//使用lock,引用下当前类
        //    {
        //        Console.WriteLine("我是Run2");
        //    }
        //}




    }
}
