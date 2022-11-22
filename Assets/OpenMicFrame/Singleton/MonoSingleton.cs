using UnityEngine;

namespace Framework.Singleton
{
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