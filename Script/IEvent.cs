using System;
using Core.EventSystem.Base.Delegates;

namespace Core.EventSystem.Base.Interfaces
{
    public interface IEvent
    {
        int InnerID { get; }
        string Name { get; }
        bool IsEnabled { get; }
        event EventDelegate Listeners;
        void Enable();
        void Disable();
        void Active();
    }

    interface IEventWithReturn<ReturnType> : IEvent
    {
        new event EventFunc<ReturnType> Listeners;
        new ReturnType Active();
    }

    interface IEvent<T> : IEvent
    {
        new event EventDelegate<T> Listeners;
        void Active(T obj);
    }

    interface IEventWithReturn<T, ReturnType> : IEventWithReturn<ReturnType>
    { 
        new event EventFunc<T, ReturnType> Listeners;
        ReturnType Active(T obj);
    }
}