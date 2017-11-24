using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18._桥接模式_之如何化解一个多维度的应用场景分析之对现阶段很火的microservice概念理解
{
    class Program
    {
        static void Main(string[] args)
        {

            PhoneBrand phone = new TianyuAddress();//天宇和address耦合在一起.
            phone.Run();
        }
    }
}
