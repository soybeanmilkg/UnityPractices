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
using UnityEngine;
using GamePoint.Game.Command;

namespace GamePoint.Game
{
    public class Enemy : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Destroy(gameObject);
            new KillEnemyCommand().Execute();
        }
    }
}