// /**
//  * File Name: FSM.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/22
//  * Descrption:
//  *
//  */

using System.Collections.Generic;

namespace Framework.FSM
{
    /// <summary>
    /// 有限状态机基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FSM<T> where T : class, new()
    {
        private FSMState<T> curState;
        private FSMState<T> toState;
        private FSMState<T> tempState;

        private Dictionary<int, FSMState<T>> stateHash = new Dictionary<int, FSMState<T>>();

        public FSM(T owner)
        {
        }

        public void Destroy()
        {
            curState?.Exit(this);
            curState = null;
            toState = null;
            // using (var itr = stateHash.GetEnumerator())
            // {
            //     while (itr.MoveNext())
            //     {
            //         itr.Current.Value.Exit(this);
            //     }
            // }
            stateHash.Clear();
        }

        public void AddState(FSMState<T> state)
        {
            if (state != null && !stateHash.ContainsValue(state))
            {
                stateHash.Add(state.StateType(), state);
            }
        }

        public void ChangeState(int stateType)
        {
            toState = stateHash[stateType];
        }

        public void Update(float fTick)
        {
            if (null != toState)
            {
                tempState = toState;
                toState = null;

                curState?.Exit(this);
                tempState?.Enter(this);

                curState = tempState;
            }

            curState?.Update(this, fTick);
        }

        public void FixedUpdate(float fTick)
        {
            curState?.FixedUpdate(this, fTick);
        }

        public void LateUpdate(float fTick)
        {
            curState?.LateUpdate(this, fTick);
        }
    }
}