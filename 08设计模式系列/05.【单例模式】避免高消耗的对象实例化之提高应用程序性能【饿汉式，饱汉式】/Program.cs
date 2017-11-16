using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _05._单例模式_避免高消耗的对象实例化之提高应用程序性能_饿汉式_饱汉式_
{
    class Program
    {
        static void Main(string[] args)
        {
            // //如果每次new的话,每次都需要5s
            // //so new一个db的代价很大,当实例化一个类时,必然调用构造函数,绕不开
            // var db = new DB();
            // db.Show();

            ////此时需要5s
            //db = new DB();//可能在项目的中其他地方需要调用db
            // db.Show();



            //var db = DB.GetInstance();
            //db.Show();

            ////此时秒执行
            //db = DB.DBInstance;// 可能在项目的中其他地方需要调用db
            //db.Show();


            Task.Factory.StartNew(() =>
            {
                var db = DB.GetInstance();
                db.Show();
            });
            //Task.Factory.StartNew(() =>
            //{
            //    var db = DB.GetInstance();
            //    db.Show();
            //});
            //Task.Factory.StartNew(() =>
            //{
            //    var db = DB.GetInstance();
            //    db.Show();
            //});
            //Task.Factory.StartNew(() =>
            //{
            //    var db = DB.GetInstance();
            //    db.Show();
            //});


            Console.WriteLine("主线程当前时间为:{0}", DateTime.Now);

            Console.Read();

        }
    }
    public class DB
    {
        //static 就是一个小缓存。。。 只要类加载（在clr中进行了加载），它就加载。
        private static DB db = null;
        private static object lockme = new object();
    

        private DB()//外界无法通过构造函数new, 也就是说构造函数不能被执行.
        {
            //构造函数需要消耗5s
             Thread.Sleep(1000 * 5);// 能想到如何模拟吗? 不能的话,就不能猜想出大概情况, 有可能会困在这里,卡住.   为什么不能理解这样模拟?
        }
        public static DB GetInstance()//封装为方法
        {
            //1,如果没有if (db == null)此判断,貌似也可以,但每次都要锁住资源,性能不高.   为什么没想到?
            //2.在第一个获取锁的线程的new,没有完成时,会进去几个线程,进行锁排队等待
            //3.在第一个获取锁的线程的new,完成时,再后续的线程不执行if语句,直接return db.
            
            if (db == null)
            {
                //多线程下,什么情况会有多个线程锁排队,什么情况下没有线程锁排队
                //lock (lockme)//最开始的时候,所有的线程都判断db为null,此时争抢锁,获取锁的线程执行方法体内,其他线程排队的等待,重复争抢锁, 直至所有的线程都获取锁,也就是说都会执行中方法体内代码,此时都会执行new
                //{
                //    Console.WriteLine("线程id为{0},想new一下", Thread.CurrentThread.ManagedThreadId);
                //    db = new DB();//需要的时候再加载
                //}


                //多线程下,什么情况会有多个线程锁排队,什么情况下没有线程锁排队
                lock (lockme)//最开始的时候,所有的线程都判断db为null,此时争抢锁,获取锁的线程执行方法体内,其他线程排队的等待,重复争抢锁, 直至所有的线程都获取锁,也就是说都会执行中方法体内代码,
                {
                    if (db == null)//只有第一个获取锁的线程执行new
                    {
                        Console.WriteLine("线程id为{0},想new一下", Thread.CurrentThread.ManagedThreadId);
                        db = new DB();//需要的时候再加载
                    }
                    //else//第一个之后的其他线程, 执行else, 当没有else时,向上退出语句块
                    //{
                    //    Console.WriteLine("线程id为{0},db已经有数据", Thread.CurrentThread.ManagedThreadId);
                    //}
                }


            }

            //多调试下,看下代码执行的路径
            //顺序执行, if执行完,肯定会执行接下来两句的
            Console.WriteLine("线程id为{0},db已经有数据", Thread.CurrentThread.ManagedThreadId);
            return db;

        }
        public  static DB DBInstance//封装为属性
        {
            get
            {
                if (db == null)//需要的时候再加载
                {
                    db = new DB();
                }
                return db;
            }
            
        }

    

        public void Show()
        {
            Console.WriteLine("线程id为:{1},执行当前时间为:{0}",DateTime.Now,Thread.CurrentThread.ManagedThreadId);
        }

        //执行此方法,不要构造函数
        public static void Show2()
        {
            Console.WriteLine("执行当前时间为:{0}", DateTime.Now);
        }
        //执行此方法,不要构造函数
        public static void Show3()
        {
            Console.WriteLine("执行当前时间为:{0}", DateTime.Now);
        }
    }
}
