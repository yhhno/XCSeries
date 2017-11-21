using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._代理模式_之通过wcf远程代理看透其中的精髓
{
    public class Proxy : AbstractDatabase//代理类为什么要实现AbstractDatabase类呢 也就是是映射了: 事情一件都不能少的如何算是一件都不能少?
    {
        Sqlserver sqlserver = new Sqlserver();//代理类屏蔽了真实对象的复杂性
        public override void Add()//也有可能是代理类抽象成更少的方法,类似个人买房.
        {
            sqlserver.Add();//代理类屏蔽了真实对象的复杂性
        }

        public override void Remove()
        {
            sqlserver.Remove();
        }
    }
}