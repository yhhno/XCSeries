using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _06._原型模式_之避免实例化的方式获取一个对象的运行状态模式分析
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person()
            {
                Name = "jack",
                Age = 22,
                Address = new Address()//此时明明赋值了,为什么person.Address为null?  什么地方出错了? 预期是要赋值,但没有赋值,残存的道理就是肯定是赋值出了问题,做一个操作肯定是有目的的,或者为了某个目的去做某件事
                {
                    City = "上海",
                    Province = "上海"
                }
            };

            //叫做动态获取一个类的运行状态, 原来如此, 运行状态是这样理解的?
            //var person2 = person.Clone();  //出了问题? 1.address没有, 2.此时获取对象为object类型, object与person有啥区别?  但值都有

            ////clone切断了引用地址.   person本身就是引用类型
            //var person2 = (Person)person.Clone();//认真
            //person2.Address = (Address)person.Address.Clone();//既然定义了,肯定要调用下了


            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, person);
            ms.Seek(0, SeekOrigin.Begin);
            var person2 = (Person)bf.Deserialize(ms);
            ms.Close();



            Console.WriteLine("执行结束");
            Console.Read();
        }
    }
}
