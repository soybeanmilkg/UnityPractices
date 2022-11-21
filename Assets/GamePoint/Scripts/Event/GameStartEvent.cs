// /**
//  * File Name: Assets/GamePoint/Srcipts/Event/GameStartEvent.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/21 23:35
//  * Descrption:
//  *
//  */

using System;
using System.ComponentModel.Design;

namespace GamePoint.Event
{
    public static class GameStartEvent
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