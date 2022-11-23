// /**
//  * File Name: KillEnemyCommand.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 23:10
//  * Descrption:
//  *
//  */

using GamePoint.Event;
using GamePoint.Framework.Command;
using GamePoint.Model;
using UnityEngine;

namespace GamePoint.Scripts.Command
{
    public struct KillEnemyCommand : ICommand
    {
        public void Execute()
        {
            GameModel.killCount.Value++;
            if (GameModel.killCount.Value == 10)
            {
                GamePassEvent.Trigger();
            }
        }
    }
}