using System;

namespace Framework.Singleton
{
    public abstract class Singleton<T>
    {
        public static T Instance { get; } = Activator.CreateInstance<T>();
    }
}