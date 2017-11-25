using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _21._组合模式_之如何将poco格式的数据朔形为树形结构分析
{
    /// <summary>
    /// 叶节点
    /// </summary>
    public class Leaf : Component
    {
        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

       

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Display(int depth)
        {

            Console.WriteLine(new string('-', depth)+"  "+this.Name);

        }
    }
}