using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication25
{
    public abstract class AbstractState
    {
        public abstract void Handler(Context context);
    }
}