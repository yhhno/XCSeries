using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._模板方法模式_教你如何使用多态将可变部分延迟到子类之实际案例展示
{
    public class ZhangSan : Exam//子类来执行可变的
    {
        public ZhangSan() //构造函数中给属性赋值.
        {
            this.Name = "张三";//将可变的延迟到子类 属性赋值1
        }
        public override string Answer()//将可变的延迟到子类
        {
            return "A";
        }
        public override string Name { get => "李四"; }//将可变的延迟到子类 属性赋值2
    }
}