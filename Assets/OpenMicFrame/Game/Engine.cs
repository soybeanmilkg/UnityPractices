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
using OpenMicFrame.Framework.Event;
using UnityEngine;

namespace Framework.Game
{
    /// <summary>
    /// 组合各管理类，提供基础服务
    /// </summary>
    public sealed class Engine : Singleton<Engine>
    {
        public ILog logger;
        public EventMgr eventMgr;
        public void Init()
        {
            logger.Log(ELogType.Debug, "Game", "Engine Init");
            eventMgr = new EventMgr();
        }

        public void SetUp()
        {
            logger.Log(ELogType.Debug, "Game", "Engine SetUp");
        }
    }
}