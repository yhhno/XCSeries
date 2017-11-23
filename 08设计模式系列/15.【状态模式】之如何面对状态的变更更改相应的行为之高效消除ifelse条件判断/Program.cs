using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._状态模式_之如何面对状态的变更更改相应的行为之高效消除ifelse条件判断
{
    class Program
    {
        static void Main(string[] args)
        {
            //设置当前状态
            Context context = new Context();
            context.State = new ConcreateState1();

            context.Request();
            context.Request();
            context.Request();
            context.Request();
            context.Request();
            context.Request();

            Console.Read();
        }
    }
}
