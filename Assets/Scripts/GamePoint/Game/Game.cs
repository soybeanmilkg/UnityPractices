// /**
//  * File Name: Assets/GamePoint/Srcipts/Game/Game.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/21 23:42
//  * Descrption:
//  *
//  */

using System;
using GamePoint.Game.Event;
using UnityEngine;

namespace GamePoint.Game
{
    public class Game : MonoBehaviour
    {
        #region Lifecycle

        private void Awake()
        {
            GameStartEvent.Register(OnGameStart);
        }

        private void OnDestroy()
        {
            GameStartEvent.Unregister(OnGameStart);
        }

        #endregion

        #region Event

        /// <summary>
        /// 游戏开始
        /// </summary>
        private void OnGameStart()
        {
            transform.Find("Enemies").gameObject.SetActive(true);
        }

        #endregion
    }
}