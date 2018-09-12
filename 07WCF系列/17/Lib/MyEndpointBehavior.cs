using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class MyEndpointBehavior : IEndpointBehavior
    {

        public string UserName { get; set; }


        public string Password { get; set; }

        public MyEndpointBehavior()//service端使用
        {

        }
        public MyEndpointBehavior(string username, string password)//client端使用
        {
            this.UserName = username;
            this.Password = password;
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// 这个是在 client 端实现的
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="clientRuntime"></param>
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new MyClientMessageInspector(this.UserName, this.Password));
        }

        /// <summary>
        /// 这个是 service 端实现的
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="endpointDispatcher"></param>
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new MyDispatchMessageInspector());
        }

        public void Validate(ServiceEndpoint endpoint)
        {

        }
    }
}
