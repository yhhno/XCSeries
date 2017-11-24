using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19._装饰器模式_之如何动态化的对组件进行装饰之对Stream的理解
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.先有个手机
            Phone phone = new ApplePhone();

            //2.再有配件
            Decorate sticker = new Sticker();
            Decorate accessories = new Accessories();

            //3.先装配贴膜
            sticker.SetDecorate(phone);

            //4.在装配挂件,注意:是将挂件装配到已经贴膜的手机上
            accessories.SetDecorate(sticker);//如何实现 是将挂件装配到已经贴膜的手机上

            //5.显示下装配结构
            accessories.show();
        }
    }
}
