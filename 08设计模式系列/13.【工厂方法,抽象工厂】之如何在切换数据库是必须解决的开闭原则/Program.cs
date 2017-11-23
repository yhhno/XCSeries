using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._工厂方法_抽象工厂_之如何在切换数据库是必须解决的开闭原则
{
    class Program
    {
        static void Main(string[] args)
        {

            ////简单工厂
            //var user = Factory.CreateInstance("sqlserver");//切换的话只修改字符串即可,但新增有点缺点
            //user.Add();


            //工厂方法
            IFactory factory = new SqlliteFactory();//切换的话,要修改1000处,但新增的话,只添加新类即可.
            var user = factory.CreateIntance();
            user.Add();




            Console.Read();
        }
    }
}
