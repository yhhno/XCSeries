using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _15.Task核心调度器_TaskScheduler_之线程池任务和同步上下文任务介绍以及如何自定义TaskScheduler编码实践
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(() =>
            {
                Thread.Sleep(1000 * 10);
                Console.WriteLine("你好");
            });
            task.Start(new PerThreadTaskScheduler());

            Console.Read();
        }
    }
    public class PerThreadTaskScheduler : TaskScheduler
    {
        /// <summary>
        /// 给debug用的
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return Enumerable.Empty<Task>();
        }

        /// <summary>
        /// 执行task
        /// </summary>
        /// <param name="task"></param>
        protected override void QueueTask(Task task)
        {
            var thread = new Thread(()=> {
                TryExecuteTask(task);
            });
            thread.Start();
        }

        /// <summary>
        /// 同步执行
        /// </summary>
        /// <param name="task"></param>
        /// <param name="taskWasPreviouslyQueued"></param>
        /// <returns></returns>
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return true;
        }
    }
}
