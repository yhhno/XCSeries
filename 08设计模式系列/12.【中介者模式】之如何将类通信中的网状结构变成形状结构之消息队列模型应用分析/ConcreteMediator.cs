using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12._中介者模式_之如何将类通信中的网状结构变成形状结构之消息队列模型应用分析
{
    public class ConcreteMediator : AbstractMediator
    {
        //为什么不定义到父类? 因为这是具体的实现
        private List<AbstractColleague> colleaguelist = new List<AbstractColleague>();//存储所有的colleage的引用, 但每个人应该有自己单独的列表
        public override void Add(AbstractColleague colleague)
        {
            colleaguelist.Add(colleague);
        }


        /// <summary>
        /// 通过name从qq列表中找到指定的人,然后转发.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="msg"></param>
        public override void Send(string name,string msg)//转发操作,转发就是接收完成.
        {
            //具体的业务逻辑
            var single = colleaguelist.FirstOrDefault(i => i.UserName == name);//匹配人
            if (single!=null)
            {
                single.Receive(string.Format("{0}接收了消息:{1}", name, msg));//接收到,算是转发完成.
            }
        }
    }
}