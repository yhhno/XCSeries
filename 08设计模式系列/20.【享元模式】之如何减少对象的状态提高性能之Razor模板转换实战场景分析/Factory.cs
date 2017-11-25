using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20._享元模式_之如何减少对象的状态提高性能之Razor模板转换实战场景分析
{
    public class Factory
    {
        //线程安全的字典?  啥是线程安全? 字典在容量比较小的情况下,也是很好的,但容量非常大的时候,也是内存抗不住的,也就是要借助redis
        static IDictionary<int, FlyWeight> 
            cachedic = new ConcurrentDictionary<int, FlyWeight>();//cachedic当然也是static,你不static你怎么共享呢?
        public static FlyWeight CreateInstance(int num)//此处存在个问题.如果 num没有传进来的话, 每次还是走的new, 逻辑严谨性.
        {
            //if (cachedic.ContainsKey(num))//每次思考的都是理想情况下
            //{
            //    return cachedic[num];
            //}
            //cachedic.Add(num, new ConcreteFlyWeight());
            //return cachedic[num];


            if (cachedic.ContainsKey(num)&&num!=0)// 逻辑严谨性.
            {
                return cachedic[num];
            }
            if (!cachedic.ContainsKey(num) && num != 0)//逻辑严谨性.
            {
                cachedic.Add(num, new ConcreteFlyWeight());
            }
            return cachedic[num];
        }
    }
}