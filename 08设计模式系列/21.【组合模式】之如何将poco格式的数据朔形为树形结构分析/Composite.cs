using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _21._组合模式_之如何将poco格式的数据朔形为树形结构分析
{
    /// <summary>
    /// 非叶节点
    /// </summary>
    public class Composite : Component
    {
        public override void Add(Component component)
        {
            this.children.Add(component);
        }


        /// <summary>
        /// 遍历树形结构
        /// </summary>
        /// <param name="depth"></param>
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + "  " + this.Name);
            //相当于深度遍历
            foreach (var component in this.children)
            {
                component.Display(depth + 3);//递归调用
            }
        }

        public override void Remove(Component component)
        {
            this.children.Remove(component);
        }
    }
}