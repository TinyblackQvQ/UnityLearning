using Core.EventSystem.Base.Delegates;
using Core.EventSystem.Base.Interfaces;
using System;

namespace Core.EventSystem.Base.Classes
{
    public class Event : IEvent
    {
        public int InnerID { get; private set; }
        public string Name { get; protected set; }
        public bool IsEnabled { get; protected set; }
        public event EventDelegate Listeners;
        protected void Invoke()
        { if (IsEnabled) Listeners.Invoke(this, EventArgs.Empty); }
        public virtual void Active() => Invoke();
        public void Enable() => IsEnabled = true;
        public void Disable() => IsEnabled = false;
    }

    public class EventWithReturn<ReturnType> : Event, IEventWithReturn<ReturnType>
    {
        public new event EventFunc<ReturnType> Listeners;
        public new ReturnType Invoke()
        {
            if (IsEnabled)
            {
                return Listeners.Invoke(this, EventArgs.Empty);
            }
            else
                return default;
        }
        public new virtual ReturnType Active() => Invoke();
    }
    public class Event<T> : Event, IEvent<T>
    {
        public new event EventDelegate<T> Listeners;
        protected void Invoke(T args) { if (IsEnabled) Listeners.Invoke(this, args); }
        public virtual void Active(T args) => Invoke(args);
    }

    public class EventWithReturn<T, ReturnType> : EventWithReturn<ReturnType>, IEventWithReturn<T, ReturnType>
    {
        public new event EventFunc<T, ReturnType> Listeners;
        protected ReturnType Invoke(T args)
        {
            if (IsEnabled)
            {
                return Listeners.Invoke(this, args);
            }
            else
                return default;
        }
        public virtual ReturnType Active(T obj) => Invoke(obj);
    }
}