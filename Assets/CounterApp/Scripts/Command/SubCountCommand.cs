// /**
//  * File Name: SubCountCommand.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 22:49
//  * Descrption:
//  *
//  */

using CounterApp.Model;
using GamePoint.Framework.Command;

namespace CounterApp.Command
{
    public struct SubCountCommand :ICommand
    {
        public void Execute()
        {
            CounterModel.count.Value--;
        }
    }
}