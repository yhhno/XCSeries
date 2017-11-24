using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _18._1使用桥接模式进行解耦
{
    public class PhoneXiaomi : PhoneBrand
    {
        public override void Run()
        {
            Console.WriteLine("正在使用 小米手机");
            this.soft.Run();
        }
    }
}