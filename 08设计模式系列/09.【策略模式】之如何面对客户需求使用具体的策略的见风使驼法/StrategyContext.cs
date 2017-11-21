using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._策略模式_之如何面对客户需求使用具体的策略的见风使驼法
{
    public class StrategyContext  //什么情况下写文件,什么情况下写DB 这是策略的选择
    {
        AbstractLog log = null;
        public StrategyContext()
        {
            this.log = new FileLog();
        }
        public StrategyContext(AbstractLog log)
        {
            this.log = log;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void Write(string msg)//什么情况下写文件,什么情况下写DB 这是策略的选择
        {
            try//简单的逻辑处理
            {
                log.Wirte(msg);
            }
            catch (Exception)
            {

                log = new DBLog();
                log.Wirte(msg);
            }
        }
    }
} 