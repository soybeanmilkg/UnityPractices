// /**
//  * File Name: Assets/GamePoint/Srcipts/Game/Game.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/21 23:42
//  * Descrption:
//  *
//  */

using System;
using GamePoint.Event;
using UnityEngine;

namespace GamePoint
{
    public class Game : MonoBehaviour
    {
        private void Awake()
        {
            GameStartEvent.Register(OnGameStart);
        }

        private void OnDestroy()
        {
            GameStartEvent.Unregister(OnGameStart);
        }

        /// <summary>
        /// 游戏开始
        /// </summary>
        private void OnGameStart()
        {
            transform.Find("Enemies").gameObject.SetActive(true);
        }
    }
}