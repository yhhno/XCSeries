using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _06wcfservice
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(LoginService));
            host.Open();
            Console.WriteLine("wcf启动成功！");

            Task.Run(() => LoginService.Modify());//为什么要用task呢，直接写LoginService.Modify() 不好吗？
            //Console.Read();
            System.Threading.Thread.Sleep(int.MaxValue);//死等待，

        }
    }
}
