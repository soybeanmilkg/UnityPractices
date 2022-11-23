// /**
//  * File Name: Event.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 0:19
//  * Descrption:
//  *
//  */

using System;

namespace GamePoint.Framework.Event
{
    /// <summary>
    /// 事件基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Event<T> where T : Event<T>
    {
        private static Action mOnEvent;

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="onEvent"></param>
        public static void Register(Action onEvent)
        {
            mOnEvent += onEvent;
        }

        /// <summary>
        /// 注销事件
        /// </summary>
        /// <param name="onEvent"></param>
        public static void Unregister(Action onEvent)
        {
            mOnEvent -= onEvent;
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        public static void Trigger()
        {
            mOnEvent?.Invoke();
        }
    }
}