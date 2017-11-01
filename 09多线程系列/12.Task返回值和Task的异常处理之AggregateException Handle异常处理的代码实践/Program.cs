using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Task返回值和Task的异常处理之AggregateException_Handle异常处理的代码实践
{
    class Program
    {
        static void Main(string[] args)
        {

            ////获取Task<TResult> 的返回值.用wait方法=>既然是要返回值,肯定要task执行完后才能获取.
            //Task<int> task1 = Task.Factory.StartNew(() =>
            //{
            //    //做一些逻辑运算.
            //    return 1;
            //});
            //task1.Wait();
            //Console.WriteLine(task1.Result);
            //Console.Read();



            ////获取Task<TResult> 的返回值.用Result=>既然是要返回值,肯定要task执行完后才能获取.,肯定在属性内调用了执行的方法.
            //Task<int> task1 = Task.Factory.StartNew(() =>
            //{
            //    //做一些逻辑运算.
            //    return 1;
            //});

            //Console.WriteLine(task1.Result);
            //Console.Read();







            ////获取延续任务 的返回值.
            //Task<int> task1 = Task.Factory.StartNew(() =>
            //{
            //    //做一些逻辑运算.
            //    return 1;
            //});

            //var task2 = task1.ContinueWith<string>(t =>
            //{
            //    var num = t.Result;
            //    var sum = num + 10;
            //    return sum.ToString();
            //});
            //Console.WriteLine(task2.Result);
            //Console.Read();




            ////task1和task2 也可以实现并行计算? 啥是并行计算呢?
            ////获取Whenall 的返回值.
            //Task<int> task1 = Task.Factory.StartNew(() =>
            //{
            //    //做一些逻辑运算.
            //    return 1;
            //});
            //Task<int> task2 = Task.Factory.StartNew(() =>
            //{
            //    //做一些逻辑运算.
            //    return 2;
            //});

            ////第一种操作返回值方式
            ////var task = Task.WhenAll<int>(task1, task2);
            ////var sum = 0;
            ////foreach (var item in task.Result)//要有逻辑分析
            ////{
            ////    sum += item;
            ////}

            ////第二种操作返回值方式
            //var task = Task.WhenAll<int>(task1, task2).ContinueWith(t =>
            //{
            //    var tt = t;
            //    var sum = 0;
            //    foreach (int item in tt.Result)
            //    {
            //        sum += item;
            //    };
            //    return sum;
            //});

            //Console.WriteLine(task.Result);
            //Console.Read();





            ////Task中的多个异常的触发和获取每个异常
            //var task = Task.Factory.StartNew(() =>
            //{
            //    var childtask1 = Task.Factory.StartNew(() =>
            //    {
            //        throw new Exception(string.Format("我是childTask2的异常:{0}", DateTime.Now));
            //    },TaskCreationOptions.AttachedToParent);
            //    var childtask12 = Task.Factory.StartNew(() =>
            //    {
            //        throw new Exception(string.Format("我是childTask2的异常:{0}", DateTime.Now));
            //    }, TaskCreationOptions.AttachedToParent);
            //});


            //try
            //{
            //    task.Wait();
            //}
            //catch (AggregateException ex)
            //{

            //    foreach (var item in ex.InnerExceptions)
            //    {
            //        Console.WriteLine(string.Format("message={0},type={1}", item.InnerException.Message, item.GetType().Name));
            //    }
            //}






            //Task中的每个异常的处理
            var task = Task.Factory.StartNew(() =>
            {
                var childtask1 = Task.Factory.StartNew(() =>
                {
                    throw new Exception(string.Format("我是childTask2的异常:{0}", DateTime.Now));
                }, TaskCreationOptions.AttachedToParent);
                var childtask12 = Task.Factory.StartNew(() =>
                {
                    throw new Exception(string.Format("我是childTask2的异常:{0}", DateTime.Now));
                }, TaskCreationOptions.AttachedToParent);
            });


            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                //可能实现屏蔽异常1,向上抛出异常2.
                ex.Handle((t) => { return false; });//遍历操作?  对于集合可能是遍历操作了.  基本的是遍历, 再谈具体的操作嘛,要有个大前提.
            }


            ////单个具体的异常 的处理
            //try
            //{

            //}
            //catch (InvalidCastException ex)
            //{

            //    throw;//具体的单个异常,需要时往上抛?  为什么要往上抛呢?
            //}


            Console.Read();
        }
    }
}
