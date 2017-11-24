using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _18._1使用桥接模式进行解耦
{
    public abstract class PhoneBrand//单个维度,独立发展
    {
        protected Soft soft = null;
        public void SetSoft(Soft soft
            )
        {
            this.soft = soft;
        }
        public abstract void Run();
       
    }
}