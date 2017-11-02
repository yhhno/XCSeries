using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _14.PLinq_AsParallel_AsOrdered_并行编程和ParallelEnumerable之对任何集合做并行执行
{
    class Program
    {
        static void Main(string[] args)
        {
            ////将linq装换为Plinq
            //var nums = Enumerable.Range(0, 10);//定义一个数组
            //var query = from n in nums.AsParallel()//转换为并行
            //            select new// select 投影
            //            {
            //                thread = Thread.CurrentThread.ManagedThreadId,
            //                nums = n
            //             };
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}



            ////使用AsOrdered()
            //var nums = Enumerable.Range(0, 10).ToList();//为什么要toList//定义一个数组
            //nums[0] = 10000;//为什么要toList
            //var query = from n in nums.AsParallel().AsOrdered()//转换为并行
            //            select new// select 投影
            //            {
            //                thread = GetThreadId(),//这里可以使用方法.
            //                nums = n
            //            };
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}



            CancellationTokenSource source = new CancellationTokenSource();
            source.Cancel();
            try
            {
                var nums = Enumerable.Range(0, 10).ToList();//为什么要toList//定义一个数组
                nums[0] = 10000;//为什么要toList
                var query = from n in nums.AsParallel().AsOrdered().WithDegreeOfParallelism(Environment.ProcessorCount)
                                                                   .WithCancellation(source.Token)//以抛出异常的方式,停止
                                                                   .WithExecutionMode(ParallelExecutionMode.ForceParallelism)//强制执行并行
                                                                   .WithMergeOptions(ParallelMergeOptions.Default)
                            select new// select 投影
                            {
                                thread = GetThreadId(),//这里可以使用方法.
                                nums = n
                            };
                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }
            }
            catch (AggregateException  ex)
            {

                Console.WriteLine(ex.InnerExceptions[0].Message);
            }


            Console.Read();
        }

        static int GetThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }
    }
}
