using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._过滤器模式_之如何从多维度对一个聚合对象进行过滤的真实案例解析
{
    public interface IFilter//为什么要定义一个接口呢
    {
        List<Person> Filter(List<Person> list);//过滤嘛,残存个什么样的道理? 有进有出有操作
    }
}