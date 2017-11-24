using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17._责任链模式_之如何动态的组成处理链方便理解js冒泡机制原理
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.实例化具体的Handler
            AbstractHandler handler1 = new ConcreteHandler();
            AbstractHandler handler2 = new ConcreteHandler2();
            AbstractHandler handler3 = new ConcreteHandler3();

            ////2.调用SetHandler,形成链表
            //handler1.SetHandler(handler2);
            //handler2.SetHandler(handler3);

            //自由的组合. 自由的新增 修改
            handler1.SetHandler(handler3);

            //3.发送请求.  有时发送请求,并不一定真的有请求这个实体在.
            handler1.Request(10);

            Console.Read();
        }
    }
}
