using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._过滤器模式_之如何从多维度对一个聚合对象进行过滤的真实案例解析
{
    public class AndFilter : IFilter//为什么要定义AndFilter  为什么要继承
    {
        List<IFilter> filters = new List<IFilter>();//1.首先要有过滤器的集合,,这里可以传入多个过滤器,一起and,,这样就不需要客户端两两拼接
        public AndFilter(List<IFilter> filters)//传入过滤器的集合
        {
            this.filters = filters;
        }

        /// <summary>
        /// 将一组filter进行and运算.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<Person> Filter(List<Person> list)//主体还是过滤, 只是过滤的方式不同.
        {
            var templist = new List<Person>(list);//将数据拿出来,不影响原来的结构
            foreach (var filteritem in filters)//对原子性过滤器进行and逻辑操作.
            {
                templist = filteritem.Filter(templist); //如何实现and操作
            }
            return templist;//也就是要实现多个维度的交集,
        }
    }
}