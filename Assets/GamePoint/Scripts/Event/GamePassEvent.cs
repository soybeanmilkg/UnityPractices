// /**
//  * File Name: Assets/GamePoint/Srcipts/Event/GamePassEvent.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/21 23:47
//  * Descrption:
//  *
//  */

using System;

namespace GamePoint.Event
{
    public static class GamePassEvent
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