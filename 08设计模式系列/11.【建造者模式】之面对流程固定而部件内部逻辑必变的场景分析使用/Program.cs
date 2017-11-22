using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._建造者模式_之面对流程固定而部件内部逻辑必变的场景分析使用
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建对象.
            BuilderDirector director = new BuilderDirector(new FatPerson());//也可以有个setPerson方法,就不需要在构造函数中设定
            director.CreatePerson();//创建

            director=new BuilderDirector(new ThinPerson());//切换逻辑
            director.CreatePerson();//新创建
            Console.Read();
        }
    }
}
