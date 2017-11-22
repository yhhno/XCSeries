using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12._中介者模式_之如何将类通信中的网状结构变成形状结构之消息队列模型应用分析
{
    public abstract class AbstractColleague
    {
        public string UserName { get; set; }//标识同事.
        //发送方法
        public abstract void Send(string name, string msg);//给那个同事,发什么消息


        //接收方法 如何触发,或者体现接收消息呢? 接收接收,肯定是要自己接收的, 那怎么触发呢? 自己触发? 别人调用?
        public abstract void Receive(string msg);//接收,要接收消息,把消息打出来
    }
}