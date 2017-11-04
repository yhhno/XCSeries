using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _17._1源码级别来剖析Async和Await
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = Hello().Result;

            Console.WriteLine(info);


            var info源码 = Hello源码();

            Console.WriteLine("我去： " + info源码.Result);

            Console.Read();
        }

        static async Task<string> Hello() //代码简化到最优,
        {
            //主线程执行，底层还会调用一个 AwaitUnsafeOnCompleted 委托给线程池
            Console.WriteLine("hello world");

            //在工作线程中执行
            var x = await Task.Run(() =>
            {
                Console.WriteLine("i'm middle");

                return "i'm ok";
            });//异步部分

            Console.WriteLine("我是结尾哦:{0}", x);

            return x;
        }

        static Task<string> Hello源码()
        {
            MyStateMachine machine = new MyStateMachine();

            machine.t_builder = AsyncTaskMethodBuilder<string>.Create();//task包装器 类似TaskCompletionSource

            //TaskCompletionSource

            machine.state = -1;

            var t_builder = machine.t_builder;

            t_builder.Start(ref machine);

            return machine.t_builder.Task;
        }


    }

    public class MyStateMachine : IAsyncStateMachine
    {
        public AsyncTaskMethodBuilder<string> t_builder;

        public int state;

        private MyStateMachine machine = null;

        private TaskAwaiter<string> myawaiter;

        string result = string.Empty;

        public MyStateMachine()
        {
        }

        public void MoveNext()
        {
            try
            {
                switch (state)
                {
                    case -1:
                        Console.WriteLine("hello world");

                        var waiter = Task.Run(() =>//异步内容
                        {
                            Console.WriteLine("i'm middle");

                            return "i'm ok";
                        }).GetAwaiter();

                        state = 0;  //设置下一个状态
                        myawaiter = waiter;

                        machine = this;

                        //丢给线程池执行了。。。
                        t_builder.AwaitUnsafeOnCompleted(ref waiter, ref machine);//异步执行
                        break;

                    case 0:

                        var j = myawaiter.GetResult();

                        Console.WriteLine("我是结尾哦:{0}", j);

                        t_builder.SetResult(j);
                        break;
                }
            }
            catch (Exception ex)
            {
                t_builder.SetException(ex);  //设置t_builder的异常
            }
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }
    }
}
