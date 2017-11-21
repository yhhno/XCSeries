using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._策略模式_之如何面对客户需求使用具体的策略的见风使驼法
{
    public abstract class AbstractLog//为啥定义抽象类
    {
        public abstract void Wirte(string msg);
    }
}