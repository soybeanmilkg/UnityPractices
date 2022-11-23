// /**
//  * File Name: GameModel.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 0:29
//  * Descrption:
//  *
//  */

using GamePoint.Framework.BindableProperty;

namespace GamePoint.Game.Model
{
    public class GameModel
    {
        // 击杀数
        public static readonly BindableProperty<int> killCount = new BindableProperty<int>();

        // 金币数
        public static readonly BindableProperty<int> gold = new BindableProperty<int>();

        // 分数
        public static readonly BindableProperty<int> score = new BindableProperty<int>();

        // 最高分数
        public static readonly BindableProperty<int> bestScore = new BindableProperty<int>();
    }
}