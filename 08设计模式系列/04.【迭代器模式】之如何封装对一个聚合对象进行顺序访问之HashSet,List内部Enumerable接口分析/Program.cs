using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._迭代器模式_之如何封装对一个聚合对象进行顺序访问之HashSet_List内部Enumerable接口分析
{
    class Program
    {
        static void Main(string[] args)
        {
            //var list = new List<int>();
            //list.Add(2);
            //list.Add(22);
            //list.Add(333);
            ////foreach (var item in list)
            ////{
            ////    Console.WriteLine(item);
            ////}

            ////类似的效果 无语法糖
            //var enumerator = list.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current);
            //}




            var aggrattion = new Aggregattion();
            aggrattion.Add(11);
            aggrattion.Add(11);
            aggrattion.Add(11);

            var enumerator = aggrattion.GetEnumerator();//GetEnumerator 与Myenumerable  区别  只是封装时的名字不同而已
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
