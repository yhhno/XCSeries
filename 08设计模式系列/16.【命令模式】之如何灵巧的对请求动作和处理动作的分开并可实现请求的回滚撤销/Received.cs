using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _16._命令模式_之如何灵巧的对请求动作和处理动作的分开并可实现请求的回滚撤销
{
    public class Received//最终的执行
    {
        public void Add()
        {
            Console.WriteLine("Add方法");
        }

        public void Remove()
        {
            Console.WriteLine("Remove方法");
        }
    }
}