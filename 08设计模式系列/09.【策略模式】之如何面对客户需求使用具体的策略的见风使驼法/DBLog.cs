using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._策略模式_之如何面对客户需求使用具体的策略的见风使驼法
{
    /// <summary>
    /// 记录日志到Db的策略
    /// </summary>
    public class DBLog : AbstractLog//为啥继承呢
    {
        public override void Wirte(string msg)
        {
            //访问数据库,可能逻辑非常复杂, //访问数据库,可能逻辑非常复杂
            Console.WriteLine("记录日志到db:{0}", msg);
            Console.WriteLine("记录日志到db:{0}",msg);
        }
    }
}