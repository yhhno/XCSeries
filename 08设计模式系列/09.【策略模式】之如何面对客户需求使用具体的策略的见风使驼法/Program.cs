using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._策略模式_之如何面对客户需求使用具体的策略的见风使驼法
{
    class Program
    {
        static void Main(string[] args)
        {
            var strategyContext = new StrategyContext();
             //strategyContext = new StrategyContext(new DBLog());
            strategyContext.Write("eee");//走filelog
            strategyContext.Write("ee额鹅鹅鹅鹅鹅鹅鹅鹅鹅鹅鹅鹅鹅鹅鹅e");//走DBlog

            Console.Read();

        }
    }
}
