using _03Servicelib;//Service1
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;//ServiceHost
using System.ServiceModel.Description;//IMetadataExchange
using System.Text;
using System.Threading.Tasks;

namespace _03.Basic基础_配置文件缺点分析之如何通过在Service和Client端通过硬编码的方式抛弃配置文件提高代码灵活性
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.配置baseAddress
            ServiceHost host = new ServiceHost(typeof(Service1), new Uri("http://localhost:8733/Service1"));//类库方法的选择
            //2.添加endpoint
            host.AddServiceEndpoint(typeof(IService1), new BasicHttpBinding(), "");//""为配置endpoint节点上的address，为相对地址，

            //3.添加behavior
            var servicemeta = new ServiceMetadataBehavior
            {
                HttpGetEnabled = true,
                HttpsGetEnabled = true
            };
            var servicedebug = new ServiceDebugBehavior
            {
                IncludeExceptionDetailInFaults = false
            };
            //host.Description.Behaviors.Add(servicedebug);//默认已经存在
            host.Description.Behaviors.Add(servicemeta);

            //4.添加mex端点
            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
        

            host.Open();

            Console.WriteLine("wcf 启动成功");
            Console.ReadLine();

        }
    }
}
