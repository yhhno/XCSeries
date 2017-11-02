using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _13.并行编程新模型之三大Parallel.For_Foreach_Invoke之使用和源码分析
{
    class Program
    {
        static void Main(string[] args)
        {
            ////串行中的for 串行计算
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //}
            ////并行的for  并行计算  更强大,强大在什么地方呢?
            ////其中可能会并行运行迭代
            //Parallel.For(0, 10, (t) =>//t是如何赋给参数的
            //{
            //    Console.WriteLine(t);
            //});


            //ConcurrentStack<int> stack = new ConcurrentStack<int>();

            //CancellationTokenSource source = new CancellationTokenSource();
            //Parallel.For(0, 100,new ParallelOptions() {
            //    MaxDegreeOfParallelism=Environment.ProcessorCount-1,//保证当前还有一个线程不会参与,也就是空闲一个线程.
            //    CancellationToken= source.Token,//取消操作

            //},(item, loop) =>
            //{
            //    if (item == 10) //这个条件是嘛意思? 要有什么样的影响? 什么样的判断呢?
            //    {
            //        //System.Threading.Thread.Sleep(10000);
            //        //告知 System.Threading.Tasks.Parallel 循环应在系统方便的时候尽早停止执行。 好模糊的话呢? 不确定因素大
            //        loop.Stop(); //是对谁而言的呢? 影响谁的呢?
            //        return;
            //    }
            //});
            //Console.WriteLine(string.Join(",",stack));




            ////当时看到不会,就一脸懵逼,不知所措了,不对,这反应不对.
            //var totalNums = 0;
            //Parallel.For<int>(1, 100, () => {//TLocal是啥意思?
            //    return 0;  //初始值操作? 啥意思? 为何如此设计?
            //}, (totals, loop, current) => {//遍历操作,参数如何确定对应呢? func的最后一参数是返回值,so他必定是total,无论名称
            //    //每个线程中的各自分区的累积
            //    current += (int)totals;
            //    return current;

            //}, (total) => {//遍历操作.
            //    //聚合并行中的每个线程的累积, 也就是累积的累积? 此刻聚合是啥意思?  
            //    Interlocked.Add(ref totalNums, total);//并行中的累积如何操作?
            //});

            //Console.WriteLine(totalNums);


            ////for操作数组.
            //int[] nums = new int[12];
            //Parallel.For(0, nums.Length, (item) =>
            //{
            //    //do logic
            //    var temp = nums[item]; //item 为数组的下标
            //});



            ////foreach操作 非数组
            //Dictionary<int, int> dic = new Dictionary<int, int>
            //{
            //    {1,11 },
            //    {2,111 },
            //    {3,1111 }
            //};
            //Parallel.ForEach(dic, (item) =>//action委托是有参数的
            //{
            //    Console.WriteLine(item.Value);
            //});



            Parallel.Invoke(
                () => { Console.WriteLine("我是并行计算1,tid={0}", System.Threading.Thread.CurrentThread.ManagedThreadId); }, 
                () => { Console.WriteLine("我是并行计算2,tid={0}", System.Threading.Thread.CurrentThread.ManagedThreadId); },
                () => { Console.WriteLine("我是并行计算3,tid={0}", System.Threading.Thread.CurrentThread.ManagedThreadId); }, 
                () => { Console.WriteLine("我是并行计算4,tid={0}", System.Threading.Thread.CurrentThread.ManagedThreadId); }
                );

            Console.Read();
        }
    }
}
