// /**
//  * File Name: GamePassCommand.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 23:15
//  * Descrption:
//  *
//  */

using GamePoint.Event;
using GamePoint.Framework.Command;

namespace GamePoint.Scripts.Command
{
    public struct GamePassCommand : ICommand
    {
        public void Execute()
        {
            GamePassEvent.Trigger();
        }
    }
}