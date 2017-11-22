using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11._建造者模式_之面对流程固定而部件内部逻辑必变的场景分析使用
{
    public abstract class AbstractPerson//为啥要要定义抽象类,和抽象方法呢? 这个角度:既然是一样的东西,我们可以把它抽象成接口或者抽象类..此时非继承角度?
    {
        public abstract void CreateBody();


        public abstract void CreateHand();


        public abstract void CreateHead();


        public abstract void CreateLeg();
        
    }
}