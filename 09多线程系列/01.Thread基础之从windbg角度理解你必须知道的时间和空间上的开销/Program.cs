using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01.Thread基础之从windbg角度理解你必须知道的时间和空间上的开销
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(() => { }));
            t.Start();
            Console.ReadKey();
        }
    }
}
