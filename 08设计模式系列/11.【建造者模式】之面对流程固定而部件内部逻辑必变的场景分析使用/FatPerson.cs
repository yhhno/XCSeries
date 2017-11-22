using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11._建造者模式_之面对流程固定而部件内部逻辑必变的场景分析使用
{
    public class FatPerson : AbstractPerson
    {
        public override void CreateBody()
        {
            //这个是部件内的逻辑
            Console.WriteLine("胖人的身体");
        }

        public override void CreateHand()
        {
            //这个是部件内的逻辑
            Console.WriteLine("胖人的手");
        }

        public override void CreateHead()
        {
            Console.WriteLine("胖人的头");
        }

        public override void CreateLeg()
        {
            Console.WriteLine("胖人的脚");
        }
    }
}