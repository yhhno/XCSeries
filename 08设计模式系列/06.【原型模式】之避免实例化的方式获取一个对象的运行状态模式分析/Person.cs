using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._原型模式_之避免实例化的方式获取一个对象的运行状态模式分析
{
    [Serializable]
    public class Person : Prototype//继承为了啥?
    {
        private string name;
        private int age;

        public Person()//记录是否执行了构造函数,毕竟我们的目的是为了避免构造函数
        {
            Console.WriteLine("当前构造函数被执行:{0}",DateTime.Now);
        }

        //值类型
        public string Name { get => name; set => name = value; }
        //值类型
        public int Age { get => age; set => age = value; }

        //引用类型
        public Address Address//关联关系    关联为了啥?
        {
            //get => default(Address);
            //set//set 什么也没有
            //{
            //}

            set; get;
        }

        public override object Clone()
        {
            return this.MemberwiseClone();//当前object的浅表副本,so返回值要为object类型
        }
    }
}