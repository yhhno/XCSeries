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
    public class MyClientMessageInspector : IClientMessageInspector
    {
        public string UserName { get; set; }


        public string Password { get; set; }

        public MyClientMessageInspector(string username,string password)
        {
            this.UserName = username;
            this.Password = password;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {

        }

        /// <summary>
        /// 发送之前
        /// </summary>
        /// <param name="request"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            //1. 进行用户名，密码的塞入操作
            var username = this.UserName;
            var password = this.Password;

            request.Headers.Add(MessageHeader.CreateHeader("username", "", username));
            request.Headers.Add(MessageHeader.CreateHeader("password", "", password));

            Console.WriteLine(request.ToString());
            return request;
        }
    }
}
