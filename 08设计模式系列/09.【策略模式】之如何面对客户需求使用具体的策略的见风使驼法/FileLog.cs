using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._策略模式_之如何面对客户需求使用具体的策略的见风使驼法
{
    /// <summary>
    /// 记录日志到File的策略
    /// </summary>
    public class FileLog : AbstractLog//为啥继承呢
    {
        public override void Wirte(string msg)
        {
            if (msg.Length > 10)//简单的逻辑,实现自我保护的机制?  也就是处理下异常.
            {
                throw new Exception("");
            }

            //可能逻辑非常复杂, //访问数据库,可能逻辑非常复杂
            Console.WriteLine("记录日志到文件:{0}", msg);
        }
    }
}