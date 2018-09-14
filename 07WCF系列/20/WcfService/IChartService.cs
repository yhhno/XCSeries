using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IChartService
    {
        [OperationContract]
        Chart DoWork(string msg);
    }
}
