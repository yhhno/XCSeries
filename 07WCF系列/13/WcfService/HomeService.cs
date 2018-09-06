using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Threading;

namespace WcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class HomeService : IHomeService
    {
        public HomeService()
        {
            Console.WriteLine("我是构造函数。。。。");
        }

        public void DoWork(string msg)
        {
            Console.WriteLine("datetime={0}, msg={1}", DateTime.Now, msg);

            Thread.Sleep(3000);
        }
    }
}
