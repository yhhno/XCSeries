using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;

namespace WcfService
{
    /// <summary>
    /// Service端的契约
    /// </summary>
    [ServiceContract(CallbackContract = (typeof(ICallback)))]
    public interface ILogin
    {
        [OperationContract]
        void Login(string username);
    }

    /// <summary>
    /// 这里就相当于 “Client”的 契约
    /// </summary>
    [ServiceContract]
    public interface ICallback
    {
        [OperationContract]
        void Notify(string msg);
    }
}
