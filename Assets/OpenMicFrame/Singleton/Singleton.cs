// /**
//  * File Name: Singleton.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/22
//  * Descrption:
//  *
//  */

using System;

namespace Framework.Singleton
{
    /// <summary>
    /// 单例基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Singleton<T>
    {
        public static T Instance { get; } = Activator.CreateInstance<T>();
    }
}