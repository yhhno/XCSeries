using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace _06.Contract契约_理解WCF双工通讯中所体现的发布订阅模式思想及代码实践和xmind图分析
{
    class Program
    {
        static void Main(string[] args)
        {

            var instanceContext = new InstanceContext(new MyLoginServiceCallback());//如何实现的？  如何理解相当于一个数组
            LoginServiceReference01.LoginServiceClient loginServiceClient = new LoginServiceReference01.LoginServiceClient(instanceContext);//InstanceContext类，表示服务实例的上下文信息，  理解系服务实例，实例 什么样的实例 服务的  那个服务的， 然后是上下文信息， 如何构建上下文信息呢，什么是上下文信息呢/ InstanceContext如何实现的？ 有什么好处？ 如何借鉴？
            loginServiceClient.Login("jack");
            Console.Read();
        }
    }

    public class MyLoginServiceCallback : LoginServiceReference01.ILoginServiceCallback
    {
        public void Notify(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
