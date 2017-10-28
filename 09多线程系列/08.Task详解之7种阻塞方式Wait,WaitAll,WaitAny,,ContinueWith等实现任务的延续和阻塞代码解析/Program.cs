using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _08.Task详解之7种阻塞方式Wait_WaitAll_WaitAny__ContinueWith等实现任务的延续和阻塞代码解析
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread t = new Thread(() =>
            //{
            //    Thread.Sleep(5000);
            //    Console.WriteLine("我是工作线程1");
            //});
            //Thread t1 = new Thread(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("我是工作线程2");
            //});

            //t1.Start();
            //t.Start();
            ////两个join一起 也就是 t1 && t2 都完成了,才能执行主线程, 类似于WaitAll操作。。。 
            ////发现这种写法没有一种数组的形式,如果有更多的thread时,要有更多的join,写起来很麻烦, 
            ////而且没有类似于WaitAny  t1 ||  t2 ,只能实现and关系,不是特别灵活.
            //t.Join();//t.join能阻塞t1的执行吗?
            //t1.Join();

            //Console.WriteLine("我是主线程");
            //Console.Read();


            //Task task1 = new Task(() =>
            //{
            //    Thread.Sleep(5000);
            //    Console.WriteLine("我是工作线程1");
            //});

            //Task task2 = new Task(() =>
            //{
            //    Thread.Sleep(5000);
            //    Console.WriteLine("我是工作线程2");
            //});

            //task1.Start();
            //task2.Start();

            //var tasks = new Task[2] { task1, task2 };

            ////等待也就是阻塞,而且WaitAll()方法也比 t.join 更高级. 也更轻松地实现了 t.join的功能.
            ////当然我的参数可以是数组,
            //// Task.WaitAll(tasks);  //参数类型为数组.
            ////Task.WaitAll(task1, task2);//等待两个任务. 如何理解任务? 此时如何理解 parameter呢?




            // Task task1 = new Task(() =>
            // {
            //     Thread.Sleep(1000);
            //     Console.WriteLine("我是工作线程1: datetime:{0}",DateTime.Now);
            // });

            // Task task2 = new Task(() =>
            // {
            //     Thread.Sleep(2000);
            //     Console.WriteLine("我是工作线程2: datetime:{0}", DateTime.Now);
            // });

            // task1.Start();
            // task2.Start();


            // var tasks = new Task[2] { task1, task2 };

            ////演示 waitany,过程是怎样?算是怎样的一个特性? 
            // Task.WaitAny(tasks);








            //Task task1 = new Task(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("我是工作线程1: datetime:{0}", DateTime.Now);
            //});

            //Task task2 = new Task(() =>
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine("我是工作线程2: datetime:{0}", DateTime.Now);
            //});

            //task1.Start();
            //task2.Start();

            //task1.Wait();//类似于 t.join()
            //task2.Wait();







            //Task task1 = new Task(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("我是工作线程1: datetime:{0}", DateTime.Now);
            //});

            //Task task2 = new Task(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("我是工作线程2: datetime:{0}", DateTime.Now);
            //});
            //Task task3 = new Task(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("我是工作线程3: datetime:{0}", DateTime.Now);
            //});


            //task1.Start();
            //task2.Start();

            //Task.WhenAll(task1, task2).ContinueWith(new Action<Task>((t) => { task3.Start(); }));






            Task task1 = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("我是工作线程1: datetime:{0}", DateTime.Now);
            });

            Task task2 = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("我是工作线程2: datetime:{0}", DateTime.Now);
            });
            Task task3 = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("我是工作线程3: datetime:{0}", DateTime.Now);
            });


            task1.Start();
            task2.Start();

            Task.Factory.ContinueWhenAll(new Task[2] { task1, task2 }, (t) => { task3.Start(); });

            Console.WriteLine("我是主线程: datetime:{0}", DateTime.Now);
            Console.Read();
        }
    }
}
