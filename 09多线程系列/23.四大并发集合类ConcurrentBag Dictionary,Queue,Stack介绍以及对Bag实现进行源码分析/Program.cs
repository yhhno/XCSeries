using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _23.四大并发集合类ConcurrentBag_Dictionary_Queue_Stack介绍以及对Bag实现进行源码分析
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConcurrentBag<int> bag = new ConcurrentBag<int>();
            //int num = 0;
            //for (int i = 0; i < 5; i++)
            //{
            //    bag.Add(num++);

            //    //Task.Factory.StartNew(() =>
            //    //{
            //    //    bag.Add(num++);
            //    //    Console.WriteLine("tid:{0}", Thread.CurrentThread.ManagedThreadId);
            //    //    var subresult = 0;
            //    //    bag.TryTake(out subresult);
            //    //    Console.WriteLine(subresult);
            //    //});//wait方法的区别, 为什么线程id是一样的.

            //}
            //var result = 0;
            //bag.TryTake(out result);//移除和返回一个对象
            //Console.WriteLine("主tid:{0}", Thread.CurrentThread.ManagedThreadId);
            //Console.WriteLine(result);
            //Console.Read();



            //ConcurrentStack<int> stack = new ConcurrentStack<int>();
            //stack.Push(1);
            //stack.Push(2);
            //var result = 0;
            //stack.TryPop(out result);
            //Console.WriteLine(result);
            //Console.Read();




            //ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            //queue.Enqueue(1);
            //var result = 0;
            //queue.TryDequeue(out result);
            //Console.WriteLine(result);
            //Console.Read();



            ConcurrentDictionary<int, int> dic = new ConcurrentDictionary<int, int>();
            dic.TryAdd(1, 10);
            dic.ContainsKey(1);
            foreach (var item in dic)
            {
                Console.WriteLine(item.Key + item.Value);
            }
            Console.Read();
        }
    }
}
