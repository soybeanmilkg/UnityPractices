// /**
//  * File Name: Assets/GamePoint/Srcipts/UI/UI.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/21 23:49
//  * Descrption:
//  *
//  */

using System;
using System.Collections;
using GamePoint.Game.Event;
using UnityEngine;

namespace GamePoint.Game.UI
{
    /// <summary>
    /// UI脚本
    /// </summary>
    public class UI : MonoBehaviour
    {
        #region Lifecycle
        private void Start()
        {
            GamePassEvent.Register(OnGamePass);
        }

        private void OnDestroy()
        {
            GamePassEvent.Unregister(OnGamePass);
        }
        #endregion
        
        #region Event
        private void OnGamePass()
        {
            transform.Find("Canvas/GamePassPanel").gameObject.SetActive(true);
        }
        #endregion
    }
}