using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _08wcfservice
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class ProductService : IProductService
    {
        public Product Get(Product product)
        {
            return new Product() { ProductId=111,ProductName="1111"};
        }
    }


    public class SystemParm
    {
        public string Token { get; set; }
        public string Md5 { get; set; }
    }
    [MessageContract]
    public class Product
    {
        //系统参数
        [MessageHeader]
        public SystemParm MySystemParam { get; set; }

        //应用参数
        [MessageBodyMember]
        public int ProductId { get; set; }
        [MessageBodyMember]
        public string ProductName { get; set; }
    }
}
