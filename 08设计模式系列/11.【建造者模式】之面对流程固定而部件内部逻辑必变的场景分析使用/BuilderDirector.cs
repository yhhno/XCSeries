using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11._建造者模式_之面对流程固定而部件内部逻辑必变的场景分析使用
{
    public class BuilderDirector
    {
        AbstractPerson person = null;
        public BuilderDirector(AbstractPerson  person)//构造函数中决定:当前要创建哪一种
        {
            this.person = person;
        }
        //这个地方的子部件的执行流程是不易变的, 也就是说子部件按照一定的流程 组成起来,比如先有什么,再有什么,最后是什么?
        public void CreatePerson()//创建对象,肯定要有创建方法了.
        {
            this.person.CreateHead();
            this.person.CreateBody();
            this.person.CreateHand();
            this.person.CreateLeg();
        }
    }
}