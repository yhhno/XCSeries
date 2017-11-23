using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._备忘录模式_之如何恢复对象的某一时刻状态之真实项目中如何对一组对象进行过滤和撤销操作
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.首先一个发起者
            Originator originator = new Originator() {
                state="张三",
                state2="你好",
            };
            Console.WriteLine("原始值为:{0}",originator.state);
            //2.生成备忘录,也就是快照
            var memento=  originator.CreateMemento();

            //3.生成的快照,由第三方保管,也就是看门人caretaker
            Caretaker caretaker = new Caretaker()
            {
                memento = memento
            };

            //4.进行了修改
            originator.state = "李四";
            Console.WriteLine("进行了修改,修改后的值为:{0}", originator.state);

            //现在要撤销
            Console.WriteLine("后悔了,进行撤销...");
            originator.RecoveryMemento(caretaker.memento);


            Console.WriteLine("撤销完成...");
            //重新输出
            Console.WriteLine("进行了撤销,撤销后的值为:{0}", originator.state);
        }
    }
}
