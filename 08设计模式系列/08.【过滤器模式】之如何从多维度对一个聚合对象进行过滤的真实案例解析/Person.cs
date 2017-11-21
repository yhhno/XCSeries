using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._过滤器模式_之如何从多维度对一个聚合对象进行过滤的真实案例解析
{
    public class Person//为什么要定义Person呢
    {
        public string  Name { get; set; }
        public int Age { get; set; }
        public string  Address { get; set; }
    }
}