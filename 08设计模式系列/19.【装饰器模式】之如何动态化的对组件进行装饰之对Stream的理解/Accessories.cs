using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _19._装饰器模式_之如何动态化的对组件进行装饰之对Stream的理解
{
    public class Accessories : Decorate
    {
        public override void show()
        {
            base.show();//父类的show. 也就是手机本身的show

            //添加一些业务逻辑. 也就是实现挂件的装配情况
            Console.WriteLine("装配中...,恭喜已经对ApplePhone进行了配件装饰.");

        }
    }
}