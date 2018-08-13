using _04servicelib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _04.Basic基础_梳理wcf分层式通讯架构图_M_encoding_transport_及通过wireshark和fiddler详细分析
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
