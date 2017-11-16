using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._模板方法模式_教你如何使用多态将可变部分延迟到子类之实际案例展示
{
    class Program
    {
        static void Main(string[] args)
        {
            Exam exam = new ZhangSan();
            exam.Questions();//张三来答题  体现多态

            Exam exam2 = new LiSi();
            exam.Questions();//李四来答题  体现多态
        }
    }
}
