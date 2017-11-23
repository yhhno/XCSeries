using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15._状态模式_之如何面对状态的变更更改相应的行为之高效消除ifelse条件判断
{
    public class Context
    {
        private AbstractState state;
        public AbstractState State//把字段state封装一下, 也可以让我们去添加其他操作. 单纯字段就不可以了额
        {
            get { return state; }
            set
            {
                state = value;
                Console.WriteLine("当前的状态:{0}", state.GetType().Name);//可以让我们去添加其他操作.
            }
        }

        public void Request()//给上层的Request方法,如何理解?也就是启动. 不是启动,是行为的执行吧
        {
            this.state.Handler(this);
        }
    }
}