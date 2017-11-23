using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _16._命令模式_之如何灵巧的对请求动作和处理动作的分开并可实现请求的回滚撤销
{
    public class Invoker
    {
        //恢复的话,需要由list保存 撤销的command 复杂些
        private List<ICommand> commandlist = new List<ICommand>();//没有list怎么做恢复 撤销呢
        public  void SetCommand (ICommand command)//commandlist中的command从哪里来,从此处来
        {
            commandlist.Add(command);
        }

        /// <summary>
        /// 执行, 肯定是list的批量执行
        /// </summary>
        public void Execute()
        {
            foreach (var command in commandlist)
            {
                command.Execute();
            }
        }

        /// <summary>
        /// 撤销: 从命令列表中删除最后一条.
        /// </summary>
        public void Undo()//撤销 什么是撤销? 什么时候撤销? 发出命令后,还未执行前?
        {
            //此处边界值就不判断了
            this.commandlist.RemoveAt(this.commandlist.Count - 1);
        }
    }
}