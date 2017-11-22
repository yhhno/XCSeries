using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10._观察者模式_之使用MVVM模式实现的knockoutjs在观察者上运用
{
    public class ConcreteSubject : ISubject
    {
        List<IObserver> observerlist = new List<IObserver>();//保存观察者
        public ConcreteSubject()
        {

        }
        public string subjectstate { get; set; }

        public void Add(IObserver observer)//观察者注册
        {
            observerlist.Add(observer);
        }

        public void Nofity()//主动通知, 如何携带通知内容呢?
        {
            //通知肯定是个循环
            foreach (var observer in observerlist)
            {
                ////有可能会异步实现
                observer.Modify();//如何感知通知及通知内容,并作出反应?
            }
        }

        public void Remove(IObserver observer)//观察者移除
        {
            observerlist.Remove(observer);
        }
    }
}