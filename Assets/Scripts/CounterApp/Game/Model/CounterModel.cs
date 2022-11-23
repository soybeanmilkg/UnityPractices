// /**
//  * File Name: CounterModel.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 1:04
//  * Descrption:
//  *
//  */

using System;
using GamePoint.Framework.BindableProperty;

namespace CounterApp.Game.Model
{
    public class CounterModel
    {
        public static readonly BindableProperty<int> count = new BindableProperty<int>();
    }
}