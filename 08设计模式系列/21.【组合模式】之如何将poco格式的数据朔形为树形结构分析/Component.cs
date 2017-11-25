using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _21._组合模式_之如何将poco格式的数据朔形为树形结构分析
{
    public abstract class Component//其实也就是个树及树的操作
    {

        protected List<Component> children = new List<Component>();
        public string Name
        {
            get;set;
        }

        public abstract void Add(Component component);//添加谁,添加到哪里
        public abstract void Remove(Component component);//删除谁,从哪里删除
        public abstract void Display(int depth);

    }
}