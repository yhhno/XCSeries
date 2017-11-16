using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._简单工厂模式_之解决生产项目中的事件模型的选择及运用实战
{
    class Program
    {
        static void Main(string[] args)
        {
            ////1.最开始情况
            ////Database   依赖倒转原则
            //Database server = new Sqlserver();

            //Database server2 = new Sqlserver();

            //Database server3 = new Sqlserver();

            //Database server4 = new Sqlserver();

            ////2.需求来了,或者变动来了,,违反开闭原则
            //Database server = new Sqlite();//修改代码

            //Database server2 = new Sqlite();//修改代码

            //Database server3 = new Sqlite();//修改代码

            //Database server4 = new Sqlite();//修改代码


            ////3.使用了工厂类.  疑问来了,你不还是修改四处吗? 照样不符合开闭原则  因为此处有硬编码
            //Database server = Factory.CreateInstance("sqlite");//照样修改代码

            //Database server2 = Factory.CreateInstance("sqlite");//照样修改代码

            //Database server3 = Factory.CreateInstance("sqlite");//照样修改代码

            //Database server4 = Factory.CreateInstance("sqlite");//照样修改代码




            //4.消除硬编码  1.配置文件, 2.数据库   符合开闭原则
            var dbtype = System.Configuration.ConfigurationManager.AppSettings["dbtype"];
            Database server = Factory.CreateInstance(dbtype);//不修改代码

            Database server2 = Factory.CreateInstance(dbtype);//不修改代码

            Database server3 = Factory.CreateInstance(dbtype);//不修改代码

            Database server4 = Factory.CreateInstance(dbtype);//不修改代码
        }

    }
}
