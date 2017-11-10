using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _21.lock语法糖和Monitor的关系以及对对象同步块和CLR同步块索引的画图对其本质分析
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    Run();
                });
            }

            Console.ReadLine();
        }

        static object lockMe = new object();//引用类型? 为什么要引用类型呢?
        static int nums = 0;
        static void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                //哈哈 很简洁,  效果一样.
                lock (lockMe)
                {
                    Console.WriteLine(nums++);
                }

                //var b = false;//生成环境中的使用方式,有try b finnally
                //try
                //{

                //    //类似SpinLock, SpinLock没有印象
                //    Monitor.Enter(lockMe, ref b); //为什么要有b呢? 如果获取锁时,失败了,此时就不能退出了.,防止此类情况出现
                //    Console.WriteLine(nums++);
                //    //seLock.Release();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                //finally
                //{
                //    if (b) Monitor.Exit(lockMe); //严谨, 如果获取锁,才可以退出.
                //}
            }
        }
    }
}
