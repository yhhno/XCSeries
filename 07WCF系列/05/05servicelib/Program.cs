using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _05wcfservice
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(HomeService));
            host.Open();
            Console.WriteLine("wcf启动成功！");
            Console.Read();

        }
    }
}
