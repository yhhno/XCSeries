using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._简单工厂模式_之解决生产项目中的事件模型的选择及运用实战
{
    public class Factory
    {
        //封装了 创建实例化对象的动作
        public static Database CreateInstance(string datype)
        {

            switch (datype)//跳转语句, 分支互斥执行
            {
                case "sqlserver":
                    return new Sqlserver();
                case "sqlite":
                    return new Sqlite();
                default:
                    break;
            }
            return null;

        }
    }
}