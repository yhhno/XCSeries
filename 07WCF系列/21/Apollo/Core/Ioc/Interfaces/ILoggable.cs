﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ctrip.Framework.Apollo.Core.Ioc
{
    public interface ILoggable
    {
        void SetLogger(ILogger logger);
    }
}
