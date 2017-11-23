using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15._状态模式_之如何面对状态的变更更改相应的行为之高效消除ifelse条件判断
{
    public abstract class AbstractState
    {
        //抽象的状态下的抽象的行为?
        public abstract void Handler(Context context);//context表示状态的传递
       
    }
}