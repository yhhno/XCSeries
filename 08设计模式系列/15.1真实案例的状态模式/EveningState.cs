using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication25
{
    public class EveningState : AbstractState
    {
        public override void Handler(Context context)
        {
            Console.WriteLine("晚上好");
        }
    }
}