﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ctrip.Framework.Apollo.Core.Schedule
{
    public interface SchedulePolicy
    {
        int Fail();

        void Success();
    }
}
