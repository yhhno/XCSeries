using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13._工厂方法_抽象工厂_之如何在切换数据库是必须解决的开闭原则
{
    public class Factory
    {
        public static IUser  CreateInstance(string type)
        {
            switch (type)
            {
                case "sqlserver":
                    return new SqlserverUser();

                case "sqllite":
                    return new SqlliteUser();
                default:
                    break;
            }
            return null;//其实可以返回一个默认的类型
        }
    }
}