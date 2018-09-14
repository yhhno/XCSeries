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
    public class LoginService : ILogin
    {
        public static Dictionary<string, ICallback> channelDic = new Dictionary<string, ICallback>();

        public void Login(string username)
        {
            //获取当前client的对象 channel
            var callback = OperationContext.Current.GetCallbackChannel<ICallback>();

            channelDic[username] = callback;

            Console.WriteLine("当前username={0} 已登录", username);
        }

        public static void Modify()
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
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
