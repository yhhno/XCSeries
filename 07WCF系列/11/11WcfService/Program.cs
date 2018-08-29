using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.ServiceModel.Web;//WebServiceHost
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    class Program
    {
        static void Main(string[] args)
        {
            //3. 修改servicehost 为 WebServiceHost
           //ServiceHost host = new ServiceHost(typeof(HomeService));
            WebServiceHost host = new WebServiceHost(typeof(HomeService));

            host.Open();

            Console.WriteLine("wcf启动成功！");
            Console.Read();
        }
    }
}
