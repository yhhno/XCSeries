using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication25
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            //初始状态
            context.State = new MorningState();

            context.Hours = 12;
            //初始状态的行为的执行
            context.Request();

            Console.Read();
        }
    }
}
