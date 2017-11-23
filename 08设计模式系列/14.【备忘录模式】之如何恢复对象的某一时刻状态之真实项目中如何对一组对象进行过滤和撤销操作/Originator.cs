using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14._备忘录模式_之如何恢复对象的某一时刻状态之真实项目中如何对一组对象进行过滤和撤销操作
{
    public class Originator
    {
        public string state
        {
            get;set;
        }

        public string state2
        {
            get; set;
        }

        /// <summary>
        /// 创建备忘录: 也就是生成快照方法
        /// </summary>
        public Memento CreateMemento()
        {
            return new Memento() { state = this.state };
        }

        /// <summary>
        /// 恢复, 恢复的话 ,肯定有一个memento进来
        /// </summary>
        public void RecoveryMemento(Memento memento)
        {
            this.state = memento.state;
        }

    }
}