﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10._观察者模式_之使用MVVM模式实现的knockoutjs在观察者上运用
{
    public interface ISubject
    {
        string subjectstate { get; set; }

        void Add(IObserver observer);
        void Remove(IObserver observer);
        void Nofity();
    }
}