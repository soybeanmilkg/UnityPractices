// /**
//  * File Name: MonoSingleton.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/22
//  * Descrption:
//  *
//  */

using UnityEngine;

namespace Framework.Singleton
{
    /// <summary>
    /// Mono脚本单例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>, new()
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>() ?? new GameObject().AddComponent<T>();
                }

                return instance;
            }
        }
    }
}