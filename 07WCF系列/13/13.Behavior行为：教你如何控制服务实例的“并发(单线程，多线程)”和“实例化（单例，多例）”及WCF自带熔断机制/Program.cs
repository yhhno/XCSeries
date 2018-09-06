using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Behavior行为_教你如何控制服务实例的_并发_单线程_多线程__和_实例化_单例_多例__及WCF自带熔断机制
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(1, 100, (item) =>
            {
                Console.WriteLine(item);//item就是个索引

                ServiceReference1.HomeServiceClient client = new ServiceReference1.HomeServiceClient();

                client.DoWork(item.ToString());
            });

            Console.Read();
        }
    }
}
