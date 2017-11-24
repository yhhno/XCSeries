using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _19._装饰器模式_之如何动态化的对组件进行装饰之对Stream的理解
{
    public abstract class Decorate : Phone//抽象类继承抽象类
    {
       protected  Phone phone = null;
        public void SetDecorate(Phone phone)//配件给手机装配. 
        {
            this.phone = phone;
        }

        public override void show()//配件自己显示装配信息.
        {
            if (this.phone != null)
            {
                this.phone.show();//手机本身的show,显示手机
            }
        }
    }
}