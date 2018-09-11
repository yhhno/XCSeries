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
    public class StudentService : IStudent
    {
        public void AddStudent()
        {
            Console.WriteLine("AddStudent 成功");
        }

        public void GetStudent()
        {
            Console.WriteLine("GetStudent 成功");
        }

        public void ModifyStudent()
        {
            Console.WriteLine("ModifyStudent 成功");
        }

        public void RemoveStudent()
        {
            Console.WriteLine("RemoveStudent 成功");
        }
    }
}
