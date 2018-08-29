using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.MsmqIntegration;
using System.Text;

namespace WcfService
{
    public class HomeService : IHomeService
    {

        public Student DoGet(string id)
        {
            return new Student()
            {
                Action = "DoGet"
            };
        }

        public Student DoPost(Student student)
        {
            return new Student()
            {
                Action = "DoPost"
            };
        }

        public Student DoPut(Student student)
        {
            return new Student()
            {
                Action = "DoPut"
            };
        }

        public Student DoDelete(int id)
        {
            return new Student()
            {
                Action = "DoDelete"
            };
        }
    }
}
