using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class 顺序执行结构和循环结构分支和跳转结构
    {
        public void 单循环遍历二维数组()
        {
            int[,] 二维数组 = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            for (int i = 0; i < 9; i++)
            {
                int row = i / 3;
                int col = i % 3;
                二维数组[row, col] = 1;
            }

            Console.ReadKey();
        }
    }
}
