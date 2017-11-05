using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _18.线程同步之用户模式和内核模式锁的区别及InterLocked_SpinLock的使用
{
    class Program
    {
        public static volatile bool isStop = false;//类似一种同步锁 
        public static SpinLock spinLock;
        static void Main(string[] args)
        {

            #region 易变结构



            //var isStop = false;//共享变量
            //var t = new Thread(() =>
            //  {
            //      var isSuccess = false;
            //      while(!isStop)
            //      {
            //          isSuccess = !isSuccess;
            //      }
            //  });
            //t.Start();
            //Thread.Sleep(1000*1);
            //isStop = true;
            //t.Join();
            //Console.WriteLine("主线程执行结束!");





            //var isStop = false;//共享变量
            //var t = new Thread(() =>
            //{
            //    var isSuccess = false;
            //    while (!isStop)
            //    {
            //        Thread.MemoryBarrier();//类似一种同步锁 
            //        isSuccess = !isSuccess;
            //    }
            //});
            //t.Start();
            //Thread.Sleep(1000 * 1);
            //isStop = true;
            //t.Join();
            //Console.WriteLine("主线程执行结束!");






            //var isStop = 0;//共享变量
            //var t = new Thread(() =>
            //{
            //    var isSuccess = false;
            //    while (isStop == 0)
            //    {
            //         //类似一种同步锁 
            //        Thread.VolatileRead(ref isStop); //此方法没有object类型的参数.怎么办? 就卡壳了? 不能的?
            //        isSuccess = !isSuccess;
            //    }
            //});
            //t.Start();
            //Thread.Sleep(1000 * 1);
            //isStop = 1;
            //t.Join();
            //Console.WriteLine("主线程执行结束!");






            ////var isStop = false;//共享变量
            //var t = new Thread(() =>
            //  {
            //      var isSuccess = false;
            //      while (!isStop)
            //      {
            //          isSuccess = !isSuccess;
            //      }
            //  });
            //t.Start();
            //Thread.Sleep(1000 * 1);
            //isStop = true;
            //t.Join();
            //Console.WriteLine("主线程执行结束!");

            #endregion

            #region 互锁结构

            var sum = 0;
            Interlocked.Increment(ref sum); //sum++
            Interlocked.Decrement(ref sum);//sum--
            Interlocked.Add(ref sum, 11);//sum+value
            Interlocked.Exchange(ref sum, 111);//sum=value
            Interlocked.CompareExchange(ref sum, 222, 111);//sum==111的话 ,sum=222
            #endregion


            //5个task
            for (int i = 0; i < 5; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    Run();
                });
            }

            Console.ReadLine();
        }

        static int nums = 0;
        static void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    var b = false;
                    spinLock.Enter(ref b);//有共享的机制,能保证依次操作,顺序操作,不然在多线程中是无序执行的.
                    Console.WriteLine(nums++);//为什么没有重复.
                }
                catch ( Exception  ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    spinLock.Exit();
                }
            }
        }
    }
}
