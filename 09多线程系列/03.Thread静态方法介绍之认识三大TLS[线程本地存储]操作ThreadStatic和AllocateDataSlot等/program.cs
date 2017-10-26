using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _03.Thread静态方法介绍之认识三大TLS_线程本地存储_操作ThreadStatic和AllocateDataSlot等
{
    class Program
    {
        #region AllocateNamedDataSlot
        //static void Main(string[] args)//主线程入口
        //{
        //    //演示下t1和t2各有一个变量
        //    //首先定义一个槽位,也就是说在所有的线程上都分配了槽位,但槽位不一定都有数据
        //    //槽位中塞入一个值helloworld
        //    //现在有一个工作线程.
        //    //也就是说变量是槽位的的值,两个线程分别为工作线程和主线程.
        //    //我设置的槽位大家都是有的,但我在主线程上setdata,工作线程是获取不到的,同样的道理,我在工作线程中setdata,主线程也是获取不到的.
        //    //我们也可以分配未命名的槽位,
        //    var slot = Thread.AllocateNamedDataSlot("username");
        //    //在主线程上设置槽位,也就是helloworld只能被主线程读取,其他线程无法读取
        //    Thread.SetData(slot, "HelloWorld");

        //    var t = new Thread(() => {
        //        //工作线程获取不槽位的值. 这也就说明了演示下t1和t2各有一个变量,
        //        //也就是说如果在工作线程中设置槽位的值,主线程也是获取不到的.
        //        var obj = Thread.GetData(slot);
        //        Console.WriteLine("当前工作线程:{0}", obj);
        //    });
        //    t.Start();

        //    var obj2 = Thread.GetData(slot);
        //    Console.WriteLine("主线程:{0}", obj2);

        //    Console.Read();
        //}
        #endregion

        #region ThreadStatic
        //指示静态字段的值对于每个线程都是唯一的,也就是说程序集可见
        //[ThreadStatic]
        //static string username = string.Empty;
        //static void Main(string[] args)//主线程入口
        //{
        //    username = "helloworld";
        //    var t = new Thread(() =>
        //    {

        //        Console.WriteLine("当前工作线程:{0}", username);
        //    });
        //    t.Start();


        //    Console.WriteLine("主线程:{0}", username);

        //    Console.Read();
        //}
        #endregion



       
        static void Main(string[] args)//主线程入口
        {
            //提供数据的线程本地存储.
            ThreadLocal<string> local = new ThreadLocal<string>();
            local.Value = "HelloWorld";
            var t = new Thread(() =>
            {
              
                Console.WriteLine("当前工作线程:{0}", local.Value);
                Thread.Sleep(10000000);
            });
            t.Start();


            Console.WriteLine("主线程:{0}", local.Value);

            Console.Read();
        }


    }
}
