using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._简单工厂模式_之解决生产项目中的事件模型的选择及运用实战
{
    public class Sqlserver : Database
    {
        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }
    }
}