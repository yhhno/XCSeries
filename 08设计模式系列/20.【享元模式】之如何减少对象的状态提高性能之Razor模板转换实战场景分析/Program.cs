using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._享元模式_之如何减少对象的状态提高性能之Razor模板转换实战场景分析
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s1 = "你好";
            //string s2 = "你好";
            //var b = String.ReferenceEquals(s1, s2);
            //Console.WriteLine(b);

            //过程,很重点, 过程是由点连成线的.
            //1.第一次使用 new获取
            var flyweight1 = Factory.CreateInstance(10);

            //2.第二次使用  从CacheDic中
            var flyweight2 = Factory.CreateInstance(10);

            //验证 1.调用Equals  2.断点调试
            Console.WriteLine(flyweight1.Equals(flyweight2));

            //3.各自使用.
            flyweight1.Run("张三");
            flyweight2.Run("李四");
        }
    }
   
}
