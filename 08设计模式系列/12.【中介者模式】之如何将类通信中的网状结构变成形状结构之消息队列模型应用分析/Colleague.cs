using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12._中介者模式_之如何将类通信中的网状结构变成形状结构之消息队列模型应用分析
{
    public class Colleague : AbstractColleague
    {
        AbstractMediator mediator = null;//因为要和中介者交互呀.所以有一个引用   映射  中介者 qq
        public Colleague(string name,AbstractMediator mediator)//相当于注册, 映射 谁登陆了qq
        {
            this.UserName = name;
            this.mediator = mediator;
        }

        public override void Receive(string msg)//复杂的话,可以对msg进行判断,然后加一个回调函数.
        {
            Console.WriteLine(msg);
        }

        public override void Send(string name, string msg)
        {
            this.mediator.Send(name, msg);
        }
    }
}