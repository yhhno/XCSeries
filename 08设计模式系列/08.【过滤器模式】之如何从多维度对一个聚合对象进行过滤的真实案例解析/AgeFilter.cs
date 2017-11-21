using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._过滤器模式_之如何从多维度对一个聚合对象进行过滤的真实案例解析
{
    public class AgeFilter : IFilter//为什么要定义AgeFilter  为什么要继承
    {
        public List<Person> Filter(List<Person> list)
        {
            //这个地方可以是复杂的逻辑,此处仅为简单演示
            return list.FindAll(i => i.Age < 20);//此时的过滤条件是硬编码
        }
    }
}