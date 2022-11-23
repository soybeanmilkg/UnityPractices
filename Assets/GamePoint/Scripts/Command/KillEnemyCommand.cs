// /**
//  * File Name: KillEnemyCommand.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 23:10
//  * Descrption:
//  *
//  */

using GamePoint.Framework.Command;
using GamePoint.Model;
using UnityEngine;

namespace GamePoint.Scripts.Command
{
    public struct KillEnemyCommand : ICommand
    {
        private GameObject go;

        public GameObject GO
        {
            get => go;
            set => go = value;
        }

        public void Execute()
        {
            GameModel.killCount.Value++;
            Object.Destroy(go);
        }
    }
}