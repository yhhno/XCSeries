using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _16.CSharp多线程模型_APM_EAP_TAP_的演变历史以及Task.Factory.FromAsyc_包装类实践
{
    class Program
    {
        static void Main(string[] args)
        {
            ////APM  看文档 学知识能力?
            //FileStream fs = new FileStream(Environment.CurrentDirectory + "//1.txt", FileMode.Open);
            //var bytes = new byte[fs.Length];//数据读入的缓冲区。
            //fs.BeginRead(bytes, 0, bytes.Length, new AsyncCallback((async) =>
            //   {
            //       var nums = fs.EndRead(async);//获取返回值
            //       Console.WriteLine(nums);//为什么要在这里输出呢
            //   }), string.Empty);


            ////Task包装 APM  fs.BeginRead异步部分
            //FileStream fs = new FileStream(Environment.CurrentDirectory + "//1.txt", FileMode.Open);
            //var bytes = new byte[fs.Length];//数据读入的缓冲区。

            //var task = Task.Factory.FromAsync(fs.BeginRead, fs.EndRead, bytes, 0, bytes.Length, string.Empty);

            //var nums = task.Result;//代码少不说,还一目了然, 使用task更强大.
            //Console.WriteLine(nums);


            ////Task包装Action
            //Action aciton = () =>
            //{

            //    Console.WriteLine("转换为void返回委托的匿名函数不能有返回值");
            //};

            //var task = Task.Factory.FromAsync(aciton.BeginInvoke, aciton.EndInvoke, string.Empty);//包含了start功能.



            //我不管gettask底层是如何实现的? 我只管传入一个url,它返回我个task, 我直接操作task即可.
            //是不是很简单,重点在包装器
            var task = GetTask("http://cnblogs.com");
            var nums = task.Result;
            Console.WriteLine(nums);



            Console.Read();
        }

        //public Task GetTask(string url)
        //{
        //    WebClient client = new WebClient();
        //    client.DownloadDataCompleted += (sender, e) =>//匿名函数
        //    {

        //    };
        //    client.DownloadDataAsync(new Uri(url));
        //}


            //Task来包装, 看着多简洁明了,, 有时是自己把东西想复杂了.
        public static Task<int> GetTask(string url)
        {
            TaskCompletionSource<int> source = new TaskCompletionSource<int>();
            WebClient client = new WebClient();
            client.DownloadDataCompleted += (sender, e) =>//匿名函数
            {
                try
                {
                    //如果下载完成了,将当前的byte[] 个数给task包装器
                    source.TrySetResult(e.Result.Length);//获取返回值
                }
                catch (Exception ex)
                {
                    //如果发生异常,将异常传递给source
                    source.TrySetException(ex);
                }
            };
            client.DownloadDataAsync(new Uri(url));//异步部分

            return source.Task;
        }


        //DownloadDataTaskAsync  是啥意思? 已经实现了task包装  是不是给async和await使用.
        public static Task<byte[]> GetTaskAsync(string url)
        {
           
            WebClient client = new WebClient();
         
            return client.DownloadDataTaskAsync(new Uri(url));//异步部分

           
        }


    }
}

