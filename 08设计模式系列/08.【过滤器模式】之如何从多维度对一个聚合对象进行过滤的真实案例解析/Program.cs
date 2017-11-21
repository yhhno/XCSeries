using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._过滤器模式_之如何从多维度对一个聚合对象进行过滤的真实案例解析
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>();//定义聚合
            persons.Add(new Person() { Age = 15, Address = "33", Name = "33" });
            persons.Add(new Person() { Age = 15, Address = "33", Name = "33" });
            var filterList = new IFilter[3]//定义过滤器集合
            {
                new AgeFilter(),
                new EmailFilter(),
                new  AddressFilter()
            };

            var andfiler = new AndFilter(filterList.ToList());//and逻辑过滤器
            var list = andfiler.Filter(persons);//过滤
        }
    }
}
