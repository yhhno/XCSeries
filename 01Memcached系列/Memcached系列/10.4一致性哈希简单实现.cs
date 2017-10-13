using System;
using System.Collections.Generic;


namespace Memcached脉络
{
    class _10
    {
	  public void 一致性哈希()
        {
            string[] iplist = new string[] { "192.168.10.1", "192.168.10.2", "192.168.10.3" };

            /*
             *  第一步：  根据实IP，生成5个虚拟IP。
             *  第二步：  将“虚拟ip”和“实际ip”应对起来。 【字典】 php=> array  java => set/hashmap
             */

            Dictionary<string, string> vitualIPDic = new Dictionary<string, string>();

            foreach (var ip in iplist)
            {
                for (int i = 0; i < 500; i++)
                {
                    vitualIPDic.Add(string.Format("{0}#{1}", ip, i), ip);
                }
            }

            /*
             * 第三步：我们需要将 虚拟ip hash化。 【hash算法】  将string => hash => int
             *
             * 第四步：将vitualip的hash码 和 我们的 ip对应起来。 也就是说通过hash码来找真实的ip
                       【为了能够找到找到key的顺时针最近memcache节点，我们准备用“红黑树，平衡二叉树”】
             */

            //key: hash   value: vitualIP
            SortedList<int, string> sortHashIP = new SortedList<int, string>();

            var rand = new Random();

            foreach (var vitualIP in vitualIPDic.Keys)
            {
                sortHashIP.Add(rand.Next(), vitualIP);
            }




            /*
             *  最后，我们就要根据key来获取memcache数据，同样的道理，我们也要将key虚拟化成hash码，
             *
             *        也就是说该key的顺时针最接近的memcache节点。

                       eg: key1= 100    

                           m1#1: 90
                           m2#1: 105
                           m3#2: 110
             */

            var key = 1238739870;  //12亿  hash值  ，其实key可能是一个值。

            var item = sortHashIP.FirstOrDefault(i => i.Key > key);

            var trueIP = vitualIPDic[item.Value];
        }
    }
}
