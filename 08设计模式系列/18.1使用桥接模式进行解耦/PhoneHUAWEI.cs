using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _18._1使用桥接模式进行解耦
{
    public class PhoneHUAWEI : PhoneBrand
    {
        public override void Run()
        {
            Console.WriteLine("正在使用 HUAWEI手机");
            this.soft.Run();
        }
    }
}