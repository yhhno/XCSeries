using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13._工厂方法_抽象工厂_之如何在切换数据库是必须解决的开闭原则
{
    public class SqlserverFactory : IFactory
    {
        public IUser CreateIntance()
        {
            return new SqlserverUser();
        }
    }
}