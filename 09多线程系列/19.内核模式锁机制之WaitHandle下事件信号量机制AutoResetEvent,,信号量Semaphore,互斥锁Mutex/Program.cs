using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _19.内核模式锁机制之WaitHandle下事件信号量机制AutoResetEvent__信号量Semaphore_互斥锁Mutex
{
    class Program
    {
        static Mutex mutex = new Mutex();

        static AutoResetEvent areLock = new AutoResetEvent(false);//初始状态为非终止状态,表示此时闸机有票
        static void Main(string[] args)
        {
            areLock.WaitOne(); //塞一张火车票到闸机中，因为此时有票在闸机，所以我只能等待  =》 此时是mainthread来执行这个操作. 也就是阻塞线程

            Console.WriteLine("火车票检验通过，可以通行");

            areLock.Set();   //从闸机中取火车票   也就是停止阻塞
            
        }
    }
}
