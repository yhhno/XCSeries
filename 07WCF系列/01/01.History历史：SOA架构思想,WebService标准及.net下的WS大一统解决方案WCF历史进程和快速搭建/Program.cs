using ServiceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;//ServiceHost
using System.Text;
using System.Threading.Tasks;

namespace _01.History历史_SOA架构思想_WebService标准及.net下的WS大一统解决方案WCF历史进程和快速搭建
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Service1));//host承载Service1
            host.Open();
            Console.WriteLine("wcf启动成功");

            Console.Read();
        }
    }
}
