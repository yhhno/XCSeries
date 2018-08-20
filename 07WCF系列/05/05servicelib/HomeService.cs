using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _05wcfservice
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class HomeService : IHomeService
    {
        public  void DoWork(string msg)
        {
            //这些是输出到server端的额，可以做些监控或者日志
            var ip = Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault(i => i.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
            var info = string.Format("当前 request有 server={0} 返回message={1}", ip, msg);
            Console.WriteLine(info);
        }

      
    }

 
}
