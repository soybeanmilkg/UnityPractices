// /**
//  * File Name: Engine.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/22
//  * Descrption:
//  *
//  */

using System;
using Framework.Log;
using Framework.Singleton;
using UnityEngine;

namespace Framework.Game
{
    /// <summary>
    /// 组合各管理类，提供基础服务
    /// </summary>
    public sealed class Engine : Singleton<Engine>
    {
        public ILog logger;
        public void Init()
        {
            logger.Log(ELogType.Debug, "Game", "Engine Init");
        }

        public void SetUp()
        {
            logger.Log(ELogType.Debug, "Game", "Engine SetUp");
        }
    }
}