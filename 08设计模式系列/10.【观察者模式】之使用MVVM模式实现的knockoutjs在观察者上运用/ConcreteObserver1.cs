using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10._观察者模式_之使用MVVM模式实现的knockoutjs在观察者上运用
{
    public class ConcreteObserver1 : IObserver//如何感知通知,响应通知,也就是自我更新?
    {
        ISubject subject = null;//观察者要知道主题在哪里,获取感知内容
        string name = string.Empty;//观察者中的名字,标识自己

        public ConcreteObserver1(ISubject subject,string name)
        {
            this.subject = subject;
            this.name = name;
        }
        //主题有了修改,观察者自我更新的函数? 如何理解自我更新/
        public void Modify()//获取感知.并执行自我更新?
        {
            //具体的观察者做了什么样的反应呢? 这就是具体的业务逻辑.  有可能是同步逻辑,也就可能是相应的响应.
            Console.WriteLine("{0}被修改了,{1}做出了反应",subject.subjectstate,this.name  );
        }
    }
}