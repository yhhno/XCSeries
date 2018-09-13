using StackExchange.Redis;
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

            host.Open();

            //将url塞入redis中
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("192.168.23.193:6379");

            var database = redis.GetDatabase();

            var url = host.Description.Endpoints[0].Address.ToString();

            var b = database.SetAdd("url", url);

            Console.WriteLine("url={0} 插入 redis的状态:{1}", url, b);

            Console.WriteLine("wcf启动成功！");
            Console.Read();
        }
    }
}
