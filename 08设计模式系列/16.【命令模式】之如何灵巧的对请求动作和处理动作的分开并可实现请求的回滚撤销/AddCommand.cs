using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _16._命令模式_之如何灵巧的对请求动作和处理动作的分开并可实现请求的回滚撤销
{
    public class AddCommand : ICommand//相当于小代理,小封装,或者包装器?
    {
        Received received = null;
        public AddCommand(Received received)
        {
            this.received = received;
        }
        public void Execute()//为什么不在此实现具体的操作.非要单独个类呢? 和预想的不一样?
        {
            received.Add();
        }
    }
}