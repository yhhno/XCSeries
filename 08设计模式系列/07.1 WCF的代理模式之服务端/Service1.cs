﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _07._1_WCF的代理模式之服务端
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Service1 : IService1
    {
        public string DoWork(string msg)
        {
            return "Hello" + msg;
        }
    }
}
