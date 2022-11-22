// /**
//  * File Name: Assets/GamePoint/Srcipts/UI/UI.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/21 23:49
//  * Descrption:
//  *
//  */

using System;
using System.Collections;
using GamePoint.Event;
using UnityEngine;

namespace GamePoint.UI
{
    public class UI : MonoBehaviour
    {
        private void Start()
        {
            GamePassEvent.Register(OnGamePass);
        }

        private void OnDestroy()
        {
            GamePassEvent.Unregister(OnGamePass);
        }

        private void OnGamePass()
        {
            transform.Find("Canvas/GamePassPanel").gameObject.SetActive(true);
        }
    }
}