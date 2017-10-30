using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace _04.Thread静态方法介绍之通过经典releaseBug认识MemoryBarrier_等如何禁止编译器优化和Cache读取
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread.MemoryBarrier();
            //Thread.VolatileRead();


            //先找文件路径,在读取,在转化成int,最后tolist. 然后循环5次. web和非web的路径是不一样的.
            //Select 是干嘛用? 当然不是现象中select
            //IEnumerable, List,ToList(),Select() 有了新的认识.
            var path = Environment.CurrentDirectory + "//1.txt";
            var list = System.IO.File.ReadAllLines(path).Select(i => Convert.ToInt32(i)).ToList();
            for (int i = 0; i < 5; i++)//为什么要循环5次呢
            {
                var watch = Stopwatch.StartNew();
                BubbleSort(list);
                watch.Stop();
                Console.WriteLine(watch.ElapsedMilliseconds);
            }
            Console.Read();
        }

        //冒泡排序算法
        static List<int> BubbleSort(List<int> list)
        {
            int temp;
            //第一层循环： 表明要比较的次数，比如list.count个数，肯定要比较count-1次
            for (int i = 0; i < list.Count - 1; i++)
            {
                //list.count-1：取数据最后一个数下标，
                //j>i: 从后往前的的下标一定大于从前往后的下标，否则就超越了。
                for (int j = list.Count - 1; j > i; j--)
                {
                    //如果前面一个数大于后面一个数则交换
                    if (list[j - 1] > list[j])
                    {
                        temp = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }
    }
}
