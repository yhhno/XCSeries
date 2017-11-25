using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._组合模式_之如何将poco格式的数据朔形为树形结构分析
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.先定义结点
            Composite root = new Composite() { Name = "root" };//表示结点

            Composite net_tech = new Composite() { Name = "net技术" };//表示结点

            //2.添加子节点
            net_tech.Add(new Leaf() { Name = "net新手" });//表示父子关系
            net_tech.Add(new Leaf() { Name = "C#" });//表示父子关系

            root.Add(net_tech);//表示父子关系

            //3.定义结点
            Composite language = new Composite() { Name = "编程语言" };//表示结点

            //4.添加子节点
            language.Add(new Leaf() { Name = "Java" });//表示父子关系

            root.Add(language);//表示父子关系

            //5.展示
            root.Display(1);
        }
    }
}
