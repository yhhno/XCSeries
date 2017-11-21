using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._代理模式_之通过wcf远程代理看透其中的精髓
{

    public abstract class AbstractDatabase//为啥定义抽象类, 定义一些必须完成的的行为? 也就映射了: 事情一件都不能少 的事情?
    {
        public abstract void Add();
        public abstract void Remove();
    }
}