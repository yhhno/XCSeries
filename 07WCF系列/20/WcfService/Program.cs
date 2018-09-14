using ProtoBuf.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ChartService));

            host.Description.Endpoints[0].EndpointBehaviors.Add(new ProtoEndpointBehavior());

            host.Open();

            Console.WriteLine("wcf启动成功！");
            Console.Read();
        }
    }
}
