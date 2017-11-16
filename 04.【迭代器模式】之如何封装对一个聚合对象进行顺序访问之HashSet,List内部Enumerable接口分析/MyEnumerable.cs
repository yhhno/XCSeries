using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._迭代器模式_之如何封装对一个聚合对象进行顺序访问之HashSet_List内部Enumerable接口分析
{
    public class MyEnumerable : IMyEnumerable
    {
        private Aggregattion aggregattion = new Aggregattion();
        private int index = 0;
        private int current = 0;

        // 枚举类是遍历聚合对象,既然你要遍历聚合对象,你肯定要有聚合对象的引用
        public MyEnumerable(Aggregattion aggregattion)
        {
            this.aggregattion = aggregattion;
        }

        public int Current { get => current; }

        public bool MoveNext()//MoveNext就是这么简单, 根本都没仔细深入 思考
        {
            if(index< aggregattion.Length)
            {
                current = aggregattion[index];//索引器是加在谁上.索引谁就在谁身上, 当时根本没思考,瞎蒙
                index++;
                return true;
            }
            return false;
        }
       
    }
}