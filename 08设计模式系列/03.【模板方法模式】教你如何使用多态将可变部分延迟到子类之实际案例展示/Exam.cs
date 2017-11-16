using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._模板方法模式_教你如何使用多态将可变部分延迟到子类之实际案例展示
{
    public abstract class Exam
    {
        public  virtual string Name { get; set; }
        public void Questions()//封装不可变
        {
            //两处可变的
            Console.WriteLine(string.Format("{0} 今天暖和吗?  {1}",Name,Answer()));
        }

        public virtual string  Answer()
        {
            return string.Empty;
        }
    }
}