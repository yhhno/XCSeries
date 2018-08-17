using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _06wcfservice
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class LoginService : ILoginService
    {

        public static Dictionary<string, ICallback> channelDic = new Dictionary<string, ICallback>();

        //public  void Login(string msg)
        public  void Login(string username)
        {
            ////这些是输出到server端的额，可以做些监控或者日志
            //var ip = Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault(i => i.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
            //var info = string.Format("当前 request有 server={0} 返回message={1}", ip, username);
            //Console.WriteLine(info);


            //获取当前client的对象或者channel或者通道
            var callback = OperationContext.Current.GetCallbackChannel<ICallback>();

            channelDic[username] = callback;

            Console.WriteLine("当前username={0}",username);
        }

        public static void Modify()
        {
            while (true)
            {
                var input = Console.ReadLine();//从控制台读东西
                if (!string.IsNullOrEmpty(input))//起到过滤回调操作的东西，因为猜想中，是执行完，就调用回调函数，一对一的，是一来一回的，其实不是的，只是，你可以调用我，我可以调用你，也就是说我调用了你，你不一定必须要紧接着调用我，
                {
                    foreach (var item in channelDic)
                    {
                        item.Value.Notify(input);
                    }
                }
            }
        }

      
    }
}
