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
    public class MyOperationBehavior : Attribute, IOperationBehavior
    {
        private int maxLength = 0;

        public MyOperationBehavior(int maxLength)
        {
            this.maxLength = maxLength;
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {

        }

        /// <summary>
        /// 客户端的behavior
        /// </summary>
        /// <param name="operationDescription"></param>
        /// <param name="clientOperation"></param>
        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {

        }

        /// <summary>
        /// 服务器端的behavior
        /// </summary>
        /// <param name="operationDescription"></param>
        /// <param name="dispatchOperation"></param>
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.ParameterInspectors.Add(new MyParameterInspector(maxLength));
        }

        public void Validate(OperationDescription operationDescription)
        {

        }
    }
}
