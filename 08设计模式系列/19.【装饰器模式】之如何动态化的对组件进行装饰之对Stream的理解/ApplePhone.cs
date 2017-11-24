using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _19._装饰器模式_之如何动态化的对组件进行装饰之对Stream的理解
{
    public class ApplePhone : Phone
    {
        public override void show()
        {
            Console.WriteLine("我是Iphone手机");
        }
    }
}