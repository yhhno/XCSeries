using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IHomeService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
               UriTemplate = "Student/{id}", BodyStyle = WebMessageBodyStyle.Bare)]
        Student DoGet(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
       UriTemplate = "Student", BodyStyle = WebMessageBodyStyle.Bare)]
        Student DoPost(Student student);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
UriTemplate = "Student", BodyStyle = WebMessageBodyStyle.Bare)]
        Student DoPut(Student student);

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
UriTemplate = "Student", BodyStyle = WebMessageBodyStyle.Bare)]
        Student DoDelete(int id);
    }

    public class Student
    {
        public string Action { get; set; }//什么用途呢.主要是返回我当前是什么样的操作， 只是说明下，并不是真的这样的作用，
    }

}
