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
    public interface IStudent
    {
        [OperationContract]
        void AddStudent();

        [OperationContract]
        void RemoveStudent();

        [OperationContract]
        void ModifyStudent();

        [OperationContract]
        void GetStudent();
    }
}
