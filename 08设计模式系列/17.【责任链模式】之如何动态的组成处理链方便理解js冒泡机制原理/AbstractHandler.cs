using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _17._责任链模式_之如何动态的组成处理链方便理解js冒泡机制原理
{
    public abstract class AbstractHandler
    {
        protected AbstractHandler handler = null;
        ////行为处理函数,
        public abstract void Request(int state);//定义为抽象,让子类去实现 ,此处有个问题,request局限于样例,或者一个角度.

        public void SetHandler(AbstractHandler handler)//组成链表的核心
        {
            this.handler = handler;
        }
    }
}