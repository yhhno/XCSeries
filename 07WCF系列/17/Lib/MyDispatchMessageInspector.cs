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
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            //request.Headers.Add(MessageHeader.CreateHeader("username", "", username));
            //request.Headers.Add(MessageHeader.CreateHeader("password", "", 12345));

            var username = request.Headers.GetHeader<string>("username", "");
            var password = request.Headers.GetHeader<string>("password", "");

            if (username == "ctrip" && password == "12345")
            {
                return request;
            }
            else
            {
                throw new Exception("用户名或者密码错误");
            }
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {

        }
    }
}
