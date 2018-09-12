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

namespace WcfService
{
    public class HomeService : IHomeService
    {
        public void DoWork(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
