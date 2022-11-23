// /**
//  * File Name: EventMgr.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 15:39
//  * Descrption:
//  *
//  */

using System;
using System.Collections.Generic;

namespace OpenMicFrame.Framework.Event
{
    public class EventMgr : IDisposable
    {
        private Dictionary<Type, IEventAggregator> eventDict = new Dictionary<Type, IEventAggregator>();

        public void AddEvent<TEvent>(Action<TEvent> handler) where TEvent : struct
        {
            var eventType = typeof(TEvent);
            if (!eventDict.TryGetValue(eventType, out var evtAggregator))
            {
                evtAggregator = new EventAggregator<TEvent>();
                eventDict.Add(eventType, evtAggregator);
            }

            var holder = (EventAggregator<TEvent>)evtAggregator;
            holder.AddEvent(handler);
        }

        public void RemoveEvent<TEvent>(Action<TEvent> handler) where TEvent : struct
        {
            var eventType = typeof(TEvent);
            if (!eventDict.TryGetValue(eventType, out var evtAggregator)) return;
            var holder = (EventAggregator<TEvent>)evtAggregator;
            holder.RemoveEvent(handler);
        }

        public void SendEvent<TEvent>(TEvent @event) where TEvent : struct
        {
            var eventType = typeof(TEvent);
            if (!eventDict.TryGetValue(eventType, out var evtAggregator)) return;
            var holder = (EventAggregator<TEvent>)evtAggregator;
            holder.SendEvent(@event);
        }

        public void Dispose()
        {
            eventDict.Clear();
        }
    }
}