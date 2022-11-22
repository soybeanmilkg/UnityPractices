using System;
using Framework.Singleton;
using UnityEngine;

namespace Framework.Game
{
    public sealed class Engine: Singleton<Engine>
    {
        public void Init()
        {
            Debug.Log("Engine Init");
        }

        public void SetUp()
        {
            Debug.Log("Engine SetUp");
        }
    }
}