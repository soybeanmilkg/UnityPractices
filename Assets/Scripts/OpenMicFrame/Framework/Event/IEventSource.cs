// /**
//  * File Name: IEventSource.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 15:40
//  * Descrption:
//  *
//  */

using System;

namespace OpenMicFrame.Framework.Event
{
    public interface IEventSource
    { }

    public interface IEventSource<in TEvent> : IEventSource where TEvent : struct
    {
        void Publish(TEvent evt);
    }

    public struct EventSource<TEvent> : IEventSource<TEvent> where TEvent : struct
    {
        public Action<TEvent> eventHandler;
        public void Publish(TEvent @event)
        {
            eventHandler?.Invoke(@event);
        }
    }
}