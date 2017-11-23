using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication25
{
    public class MorningState : AbstractState
    {
        public override void Handler(Context context)//状态行为的执行.
        {
            if (context.Hours > 0 && context.Hours < 12)//状态的检测
            {
                Console.WriteLine("早上好");
            }
            else
            {
                context.State = new NoonState();//状态的切换

                context.Request();//状态行为的执行.
            }
        }
    }
}