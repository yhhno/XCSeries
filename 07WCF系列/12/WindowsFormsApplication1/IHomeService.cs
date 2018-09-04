using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;

namespace WindowsFormsApplication1
{
    [ServiceContract]
    public interface IHomeService
    {
        [OperationContract]
        void DoWork(string msg);
    }
}
