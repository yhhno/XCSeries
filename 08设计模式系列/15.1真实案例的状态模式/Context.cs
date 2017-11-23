using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication25
{
    public class Context
    {
        private AbstractState state;

        public int Hours { get; set; }

        public AbstractState State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                Console.WriteLine("当前的状态: {0}", State.GetType().Name);
            }
        }

        public void Request()
        {
            this.state.Handler(this);
        }
    }
}