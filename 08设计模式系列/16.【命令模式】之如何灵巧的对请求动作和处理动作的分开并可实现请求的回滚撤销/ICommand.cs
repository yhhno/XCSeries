﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _16._命令模式_之如何灵巧的对请求动作和处理动作的分开并可实现请求的回滚撤销
{
    public interface ICommand
    {
        void Execute();
    }
}