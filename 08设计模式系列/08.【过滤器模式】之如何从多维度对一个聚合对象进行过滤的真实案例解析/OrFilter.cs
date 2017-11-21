using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._过滤器模式_之如何从多维度对一个聚合对象进行过滤的真实案例解析
{
    public class OrFilter : IFilter//为什么要定义OrFilter  为什么要继承
    {
        List<IFilter> filters = new List<IFilter>();//1.首先要有过滤器的集合,,这里可以传入多个过滤器,一起OR,,这样就不需要客户端两两拼接
        public OrFilter(List<IFilter> filters)//传入过滤器的集合
        {
            this.filters = filters;
        }

        /// <summary>
        /// 将一组filter进行OR运算.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<Person> Filter(List<Person> list)//主体还是过滤, 只是过滤的方式不同.
        {
            var hashset = new HashSet<Person>();
            foreach (var filteritem in filters)//对原子性过滤器进行Or逻辑操作.
            {
              var   templist = filteritem.Filter(list);//直接使用源数据,因为不破坏它的结构
                foreach (var person in templist)
                {
                    //hashset有天然的去重, 值一样,它的hashcode是一样的.
                    hashset.Add(person);//也就是要实现多个维度的并集, 有可能重复,要去重
                }
            }
            return hashset.ToList() ;
        }
    }
}