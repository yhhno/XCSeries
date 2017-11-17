using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._迭代器模式_之如何封装对一个聚合对象进行顺序访问之HashSet_List内部Enumerable接口分析
{
    public interface IMyEnumerable
    {
        int Current { get; }

        bool MoveNext();
    }
}