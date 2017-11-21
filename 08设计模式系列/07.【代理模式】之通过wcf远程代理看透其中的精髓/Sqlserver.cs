using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._代理模式_之通过wcf远程代理看透其中的精髓
{
    public class Sqlserver : AbstractDatabase//实现必不可少的事情.
    {
        public override void Add()
        {
            //这里操作非常复杂,业务逻辑很复杂,比如说跨机器
            Console.WriteLine("Sqlserver的Add操作");
        }

        public override void Remove()
        { //这里操作非常复杂,业务逻辑很复杂,比如说跨机器
            Console.WriteLine("Sqlserver的Remove操作");
        }
    }
}