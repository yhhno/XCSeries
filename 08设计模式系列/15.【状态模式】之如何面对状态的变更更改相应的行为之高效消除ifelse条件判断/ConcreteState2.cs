using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15._状态模式_之如何面对状态的变更更改相应的行为之高效消除ifelse条件判断
{
    public class ConcreteState2 : AbstractState
    {
        public override void Handler(Context context)
        {
            context.State = new ConcreteState3();//设置下一个状态,  为什么要设置呢? 不然状态咋传递? 映射 ifelse 语句的顺序
        }
    }
}