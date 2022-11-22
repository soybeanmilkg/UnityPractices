﻿using Framework.FSM;
using Framework.Game;
using UnityEngine;

namespace Framework.FSMStates
{
    public class StateEnd : FSMState<GameLauncher>
    {
     
        public override int StateType()
        {
            return (int)EGameState.End;
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        public override void Enter(FSM<GameLauncher> fsm)
        {
            Debug.Log("StateEnd Enter");
        }
        // ReSharper disable Unity.PerformanceAnalysis
        public override void Exit(FSM<GameLauncher> fsm)
        {
            Debug.Log("StateEnd Exit");
        }
        public override void FixedUpdate(FSM<GameLauncher> fsm, float fTick)
        {

        }
        public override void Update(FSM<GameLauncher> fsm, float fTick)
        {

        }
        public override void LateUpdate(FSM<GameLauncher> fsm, float fTick)
        {

        }
    }
}