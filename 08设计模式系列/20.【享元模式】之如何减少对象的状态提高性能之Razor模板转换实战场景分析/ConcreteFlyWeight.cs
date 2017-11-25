using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20._享元模式_之如何减少对象的状态提高性能之Razor模板转换实战场景分析
{
    public class ConcreteFlyWeight : FlyWeight
    {
        public override void Run(string msg)
        {
            Console.WriteLine("可变的部分:{0}",msg);
        }
    }
}