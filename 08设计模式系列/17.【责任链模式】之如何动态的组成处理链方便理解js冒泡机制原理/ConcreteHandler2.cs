using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _17._责任链模式_之如何动态的组成处理链方便理解js冒泡机制原理
{
    public class ConcreteHandler2 : AbstractHandler
    {
        public override void Request(int state)
        {
            if (state>3&&state < 7)
            {
                Console.WriteLine("当前请假天数为:{0},已被研发经理同意", state);
            }
            else
            {
                if (this.handler != null)//逻辑的严谨, 是否可用到一致性处理.
                {
                    this.handler.Request(state);//此时的handler 已经通过SetHandler所赋值,指向下一个handler,这样形成链表

                }
            }
        }
    }
}