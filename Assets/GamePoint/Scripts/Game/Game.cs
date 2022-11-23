// /**
//  * File Name: Assets/GamePoint/Srcipts/Game/Game.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/21 23:42
//  * Descrption:
//  *
//  */

using System;
using GamePoint.Event;
using GamePoint.Model;
using UnityEngine;

namespace GamePoint.Game
{
    public class Game : MonoBehaviour
    {
        #region Lifecycle

        private void Awake()
        {
            GameStartEvent.Register(OnGameStart);
            GameModel.killCount.mOnValueChanged += OnEnemyKilled;
        }

        private void OnDestroy()
        {
            GameStartEvent.Unregister(OnGameStart);
            GameModel.killCount.mOnValueChanged -= OnEnemyKilled;
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

        /// <summary>
        /// 一个敌人被击杀
        /// </summary>
        private void OnEnemyKilled(int killCount)
        {
            if (killCount == 10)
            {
                GamePassEvent.Trigger();
            }
        }

        #endregion
    }
}