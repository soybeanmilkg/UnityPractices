// /**
//  * File Name: Assets/GamePoint/Srcipts/Game/Enemy.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/21 23:10
//  * Descrption:
//  *
//  */

using System;
using System.Collections;
using System.Collections.Generic;
using GamePoint.Event;
using UnityEngine;

namespace GamePoint
{
    public class Enemy : MonoBehaviour
    {
        private static int enemyCount = 0;

        private void OnMouseDown()
        {
            enemyCount++;
            if (enemyCount == 10)
            {
                GamePassEvent.Trigger();
            }
            Destroy(gameObject);
        }
    }
}