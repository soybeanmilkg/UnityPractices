// /**
//  * File Name: BindableProperty.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 22:22
//  * Descrption:
//  *
//  */

using System;

namespace GamePoint.Framework.BindableProperty
{
    /// <summary>
    /// 绑定Model属性
    /// </summary>
    /// <typeparam name="T">属性类型，需要是可比较类型</typeparam>
    public class BindableProperty<T> where T : IEquatable<T>
    {
        private T mValue = default(T);

        public Action<T> mOnValueChanged;

        public T Value
        {
            get => mValue;
            set
            {
                if (value.Equals(mValue)) return;
                mValue = value;
                mOnValueChanged?.Invoke(mValue);
            }
        }
    }
}