using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _17.透过编译器从IL层面看异步编程await_async整个关键词的本质_最大限度的压榨IO线程_解放Work线程_
{
    class Program
    {
        static void Main(string[] args)
        {
            var info =  GetString().Result;

            Console.WriteLine(info);
            //Console.WriteLine("我是主线程");
       
            Console.Read();
        }

        static async Task<string> GetString()
        {
           
            FileStream fs = new FileStream(Environment.CurrentDirectory + "//1.txt",FileMode.Open);
            byte[] bytes = new byte[fs.Length];     
            var lent= await fs.ReadAsync(bytes, 0, bytes.Length);
            var str = Encoding.Default.GetString(bytes);
          
            return str;
        }
    }
}
