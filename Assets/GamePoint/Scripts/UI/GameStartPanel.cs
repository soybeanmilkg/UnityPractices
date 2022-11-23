// /**
//  * File Name: Assets/GamePoint/Srcipts/UI/GameStartPanel.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/21 23:18
//  * Descrption:
//  *
//  */

using System;
using GamePoint.Event;
using GamePoint.Scripts.Command;
using UnityEngine;
using UnityEngine.UI;

namespace GamePoint.UI
{
    public class GameStartPanel : MonoBehaviour
    {
        public GameObject Enemies;
        private void Start()
        {
            transform.Find("BtnStart").GetComponent<Button>().onClick.AddListener((() =>
            {
                gameObject.SetActive(false);
                new GameStartCommand().Execute();
            }));
        }
    }
}