using _07._2WCF的代理模式之客户端.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._2WCF的代理模式之客户端
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();
            var msg =client.DoWork("张三");
            Console.WriteLine(msg);
            Console.Read();
        }
    }
}
