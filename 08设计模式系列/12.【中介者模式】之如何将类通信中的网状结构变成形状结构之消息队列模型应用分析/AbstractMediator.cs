using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12._中介者模式_之如何将类通信中的网状结构变成形状结构之消息队列模型应用分析
{
    public abstract class AbstractMediator//为啥要定义此类 目的何在, 转发消息  既然是转发,有from有to 有msg  有send
    {
        //public abstract void Send(string msg);//转发,肯定是转发消息, 此时为啥没有同事呢? 按道理,发送必须要有人呢?

        public abstract void Send(string name,string msg);//转发,肯定是转发消息, 此时为啥没有同事呢? 按道理,发送必须要有人呢?
        public abstract void Add(AbstractColleague colleague);//添加同事
    }
}