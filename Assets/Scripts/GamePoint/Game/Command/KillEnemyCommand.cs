// /**
//  * File Name: KillEnemyCommand.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 23:10
//  * Descrption:
//  *
//  */

using GamePoint.Framework.Command;
using GamePoint.Game.Event;
using GamePoint.Game.Model;
using UnityEngine;

namespace GamePoint.Game.Command
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