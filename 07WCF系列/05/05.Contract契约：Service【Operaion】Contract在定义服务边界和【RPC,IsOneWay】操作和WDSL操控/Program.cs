using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Contract契约_Service_Operaion_Contract在定义服务边界和_RPC_IsOneWay_操作和WDSL操控
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.HomeServiceClient host = new ServiceReference1.HomeServiceClient();
            host.DoWork("hello");
            Console.Read();
        }
    }
}
