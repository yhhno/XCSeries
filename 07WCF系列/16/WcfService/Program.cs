using Lib;
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
            ServiceHost host = new ServiceHost(typeof(HomeService));

            //获取到 contract下的所有 operation。。。。
            var operations = host.Description.Endpoints[0].Contract.Operations;

            foreach (var item in operations)
            {
                item.OperationBehaviors.Add(new MyOperationBehavior(5));
            }

            host.Open();

            Console.WriteLine("wcf启动成功！");
            Console.Read();
        }
    }
}
