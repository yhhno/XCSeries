using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication25
{
    public class NoonState : AbstractState
    {
        public override void Handler(Context context)
        {
            if (context.Hours >= 12 && context.Hours < 14)
            {
                Console.WriteLine("中午好");
            }
            else
            {
                context.State = new EveningState();
                context.Request();
            }
        }
    }
}