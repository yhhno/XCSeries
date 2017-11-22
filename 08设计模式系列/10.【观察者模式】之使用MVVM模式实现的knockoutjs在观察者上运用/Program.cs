using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._观察者模式_之使用MVVM模式实现的knockoutjs在观察者上运用
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.首先定义一个subject
            ISubject subject = new ConcreteSubject()
            {
                subjectstate = "Hello"
            };

            //2.定义观察者
            IObserver observer1 = new ConcreteObserver1(subject, "张三");
            IObserver observer2 = new ConcreteObserver2(subject, "李四");

            //3.观察者注册到主题
            subject.Add(observer1);
            subject.Add(observer2);

            //4.主题修改
            subject.subjectstate = "天炸掉了";

            //5. 主题推送
            subject.Nofity();

            Console.Read();
        }
    }
}
