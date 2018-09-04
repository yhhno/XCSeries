using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace WcfService
{
    class Program : ConsoleBase
    {


        #region Topself 也就是windows服务
        static void Main(string[] args)
        {
            HostFactory.Run(x =>                                 //1
            {
                x.Service<ServiceHost>(s =>                        //2  泛型类型
                {
                    s.ConstructUsing(name => new ServiceHost(typeof(HomeService)));     //3  实例
                    s.WhenStarted(tc => tc.Open());              //4
                    s.WhenStopped(tc => tc.Close());               //5
                });

                x.RunAsLocalSystem();                            //6

                x.SetDescription("这是我的第一个wcf服务");        //7
                x.SetDisplayName("HomeService");                       //8
                x.SetServiceName("HomeService");                       //9
            });
        }

        #endregion



        //static void Main(string[] args)
        //{
        //    //禁用关闭‘按钮’
        //    DisableCloseButton(Console.Title);

        //    ServiceHost host = new ServiceHost(typeof(HomeService));

        //    host.Open();

        //    Console.WriteLine("wcf启动成功！");
        //    Console.Read();
        //}
    }


    public class ConsoleBase
    {
        #region 禁用关闭按钮
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, IntPtr bRevert);

        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        static extern IntPtr RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        ///<summary>
        /// 禁用关闭按钮
        ///</summary>
        ///<param name="consoleName">控制台名字</param>
        public static void DisableCloseButton(string title)
        {
            //线程睡眠，确保closebtn中能够正常FindWindow，否则有时会Find失败。。
            System.Threading.Thread.Sleep(100);

            IntPtr windowHandle = FindWindow(null, title);
            IntPtr closeMenu = GetSystemMenu(windowHandle, IntPtr.Zero);
            uint SC_CLOSE = 0xF060;
            RemoveMenu(closeMenu, SC_CLOSE, 0x0);
        }

        public static bool IsExistsConsole(string title)
        {
            IntPtr windowHandle = FindWindow(null, title);
            if (windowHandle.Equals(IntPtr.Zero)) return false;

            return true;
        }
        #endregion
    }
}
