using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _06wcfservice
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    //[ServiceContract]
    //[ServiceContract(Name ="SSSSSSSSSSSSS")]


    /// <summary>
    /// server端的契约，此契约实现当然在server端
    /// </summary>
    [ServiceContract(CallbackContract =typeof(ICallback))]

    public interface ILoginService
    {
        //[OperationContract]
        //[OperationContract(Name ="OOOOOOOO",ReplyAction = "http://tempuri.org/IHomeService/AAAAAAAResponse")]
        //[OperationContract(IsOneWay =true)]

        [OperationContract]
        //void Login(string msg);
        //void Login(string username);
        void Login(string username);//如果有返回参数，在fiddler中如何显示。

    }



   /// <summary>
   /// 这里相当于“client”的契约,此契约实现当然在client端
   /// </summary>
    [ServiceContract]
    public interface ICallback
    {
        //[OperationContract]
        //[OperationContract(Name ="OOOOOOOO",ReplyAction = "http://tempuri.org/IHomeService/AAAAAAAResponse")]
        //[OperationContract(IsOneWay =true)]

        [OperationContract]
        void Notify(string msg);

    }

}
