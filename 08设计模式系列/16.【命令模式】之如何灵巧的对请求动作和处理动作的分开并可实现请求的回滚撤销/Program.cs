using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._命令模式_之如何灵巧的对请求动作和处理动作的分开并可实现请求的回滚撤销
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.首先定义一个Received  真正的执行,此时和请求分离
            Received received = new Received();

            //2.定义Command命令  真正执行的请求, 此时和执行分离.
            ICommand command = new AddCommand(received);//AddCommand最终会被received执行
            ICommand command2 = new RemoveCommand(received);//RemoveCommand最终会被received执行

            //3.定义Invoker
            Invoker invoker = new Invoker();

            //4.添加命令到 invoker,此时list中所有的command都是待执行的命令   添加算不算发送请求. 映射 server.Add(); 
            invoker.SetCommand(command);
            invoker.SetCommand(command2);

            //做撤销
            invoker.Undo();//撤销 什么是撤销? 什么时候撤销? 发出命令后,还未执行前?

            //5.invoker调用,执行command, list中所有的command都会被执行
            invoker.Execute();//映射 Add的方法体内容.


        }
    }
}
