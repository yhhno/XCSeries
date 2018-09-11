using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class MyDispatchMessageInspector : IDispatchMessageInspector
    {
        //这个地方，大家可以用redis来实现。。。
        public static Dictionary<string, int> totalDic = new Dictionary<string, int>();

        /// <summary>
        /// 收到之后
        /// </summary>
        /// <param name="request"></param>
        /// <param name="channel"></param>
        /// <param name="instanceContext"></param>
        /// <returns></returns>
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var action = request.Headers.GetHeader<string>("Action", "http://schemas.microsoft.com/ws/2005/05/addressing/none");

            if (!totalDic.ContainsKey(action))
            {
                totalDic[action] = 0;
            }

            totalDic[action]++;

            Console.WriteLine("当前时间:{0} action={1}, 调用次数为:{2}", DateTime.Now, action, totalDic[action]);

            return request;
        }

        /// <summary>
        /// 回复之前
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="correlationState"></param>
        public void BeforeSendReply(ref Message reply, object correlationState)
        {

        }
    }
}
