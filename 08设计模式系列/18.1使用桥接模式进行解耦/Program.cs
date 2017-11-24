using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18._1使用桥接模式进行解耦
{
    class Program
    {
        static void Main(string[] args)
        {

            PhoneBrand phone = new PhoneXiaomi();//使用小米手机
            //切换手机
            phone = new PhoneHUAWEI();//换个手机,使用华为手机

            phone.SetSoft(new Game());//玩游戏
            //切换软件
            phone.SetSoft(new Address());//查通讯录.

            phone.Run();// 这是啥呢? 动作完成.
        }
    }
}
