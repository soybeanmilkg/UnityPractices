// /**
//  * File Name: AddCountCommand.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 22:48
//  * Descrption:
//  *
//  */

using CounterApp.Game.Model;
using GamePoint.Framework.Command;

namespace CounterApp.Game.Command
{
    public struct AddCountCommand : ICommand
    {
        public void Execute()
        {
            CounterModel.count.Value++;
        }
    }
}