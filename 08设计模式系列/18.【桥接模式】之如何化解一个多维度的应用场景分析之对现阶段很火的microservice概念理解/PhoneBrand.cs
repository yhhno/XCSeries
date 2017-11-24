using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _18._桥接模式_之如何化解一个多维度的应用场景分析之对现阶段很火的microservice概念理解
{
    public abstract class PhoneBrand//为什么要这样定义呢? 而不是IBrand和 ISoft借口呢?
    {
        public abstract void Run();
       
    }
}