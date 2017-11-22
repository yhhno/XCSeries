using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._中介者模式_之如何将类通信中的网状结构变成形状结构之消息队列模型应用分析
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.启动qq 中介者
            AbstractMediator mediator = new ConcreteMediator();

            //2.两个同事登录qq
            AbstractColleague colleague1 = new Colleague("张三",mediator);
            AbstractColleague colleague2 = new Colleague("李四",mediator);

            //3.添加好友列表
            mediator.Add(colleague1);
            mediator.Add(colleague2);

            //4.发送消息
            colleague1.Send("李四", "你在么");
            colleague2.Send("张三", "我在的");

            Console.Read();

        }
    }
}
