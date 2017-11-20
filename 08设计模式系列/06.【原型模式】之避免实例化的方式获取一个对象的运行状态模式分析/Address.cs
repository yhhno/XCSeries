using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._原型模式_之避免实例化的方式获取一个对象的运行状态模式分析
{
    [Serializable]
    public class Address : Prototype//:IClone
    {
        public string Province
        {
            //get => default(string);
            //set//set 什么也没有,肯定会出现赋值出错,
            //{
            //}
            get; set;

        }

        public string City
        {
            //get => default(string);
            //set//set 什么也没有
            //{
            //}
            get; set;
        }

        public override object Clone()////既然定义了,肯定要调用下了,,,,做了,肯定为了某个目的.  为了某个目的,肯定要用.
        {
            return this.MemberwiseClone();
        }
    }
}