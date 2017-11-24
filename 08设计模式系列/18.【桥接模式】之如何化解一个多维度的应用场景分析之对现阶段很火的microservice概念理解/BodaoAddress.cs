using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _18._桥接模式_之如何化解一个多维度的应用场景分析之对现阶段很火的microservice概念理解
{
    public class BodaoAddress : PhoneBodao//为什么要继承PhoneBodao呢  继承导致耦合 耦合了什么呢
    {
        public override void Run()//孙子辈的类,也可以重写 父类重写的函数
        {
            Console.WriteLine("运行波导的Address");
        }
    }
}