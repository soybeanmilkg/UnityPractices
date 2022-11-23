// /**
//  * File Name: IEventAggregator.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 15:40
//  * Descrption:
//  *
//  */

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenMicFrame.Framework.Event
{
    public interface IEventAggregator
    {
    }

    public sealed class EventAggregator<TEvent> : IEventAggregator where TEvent : struct
    {
        private readonly List<IEventSource> handlerList = new List<IEventSource>();

        public void AddEvent(Action<TEvent> handler)
        {
            var evtSource = new EventSource<TEvent>() { eventHandler = handler };
            handlerList.Add(evtSource);
        }

        public void RemoveEvent(Action<TEvent> handler)
        {
            var key = handlerList.Find(h =>
            {
                var source = (EventSource<TEvent>)h;
                return source.eventHandler == handler;
            });
            handlerList.Remove(key);
        }

        public void SendEvent(TEvent @event)
        {
            foreach (var source in handlerList.Cast<EventSource<TEvent>>())
            {
                source.Publish(@event);
            }
        }
    }
}