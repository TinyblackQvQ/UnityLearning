using System;
using Core.EventSystem.Base.Interfaces;

namespace Core.EventSystem.Base.Delegates
{ 
    public delegate void EventDelegate(IEvent sender, EventArgs e);
    public delegate void EventDelegate<Targs>(IEvent sender, Targs e);
    public delegate ReturnType EventFunc<out ReturnType>(IEvent sender, EventArgs e);
    public delegate ReturnType EventFunc<Targs, out ReturnType>(IEvent sender, Targs e);
}