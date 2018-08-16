using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _05wcfservice
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    //[ServiceContract(Name ="SSSSSSSSSSSSS")]
    public interface IHomeService
    {
        [OperationContract]
        //[OperationContract(Name ="OOOOOOOO",ReplyAction = "http://tempuri.org/IHomeService/AAAAAAAResponse")]
        //[OperationContract(IsOneWay =true)]
        void DoWork(string msg);
        
    }

  
}
