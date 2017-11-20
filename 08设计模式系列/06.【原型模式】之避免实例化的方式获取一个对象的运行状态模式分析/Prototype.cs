using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._原型模式_之避免实例化的方式获取一个对象的运行状态模式分析
{
    [Serializable]
    public abstract class Prototype//为了什么样的目的. 而作此
    {
        public abstract object Clone();//注意返回值
    }
}