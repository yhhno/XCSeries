using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._迭代器模式_之如何封装对一个聚合对象进行顺序访问之HashSet_List内部Enumerable接口分析
{
    public class Aggregattion//类似于list或hashset的 聚合对象
    {
        private List<int> list = new List<int>();//底层数组
        public MyEnumerable GetEnumerator()//读数据  读写分离
        {
            return new MyEnumerable(this);//this关键字,此时传入this.而不是list 也算是对底层数据的封装.
        }

        public void Add( int num)//写数据 读写分离
        {
            list.Add(num);
        }
        public int this[int index]//索引器
        {
            get
            {
                return list[index];
            }
        }
        public int Length//封装一个length属性
        {
            get
            {
                return list.Count;
            }
        }
    }
}