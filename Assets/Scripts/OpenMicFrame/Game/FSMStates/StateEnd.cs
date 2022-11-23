// /**
//  * File Name: StateEnd.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/22
//  * Descrption:
//  *
//  */

using Framework.Game;
using OpenMicFrame.Framework.FSM;
using OpenMicFrame.Framework.Log;
using OpenMicFrame.Game.Event;
using UnityEngine;

namespace OpenMicFrame.Game.FSMStates
{
    /// <summary>
    /// 结束状态
    /// </summary>
    public class StateEnd : FSMState<GameLauncher>
    {
        public override int StateType()
        {
            return (int)EGameState.End;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public override void Enter(FSM<GameLauncher> fsm)
        {
            Engine.Instance.logger.Log(ELogType.Debug, "Game",
                "<color=cyan>------------------StateEnd Enter-----------------</color>");
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public override void Exit(FSM<GameLauncher> fsm)
        {
            Engine.Instance.logger.Log(ELogType.Debug, "Game",
                "<color=cyan>------------------StateEnd Exit-----------------</color>");
        }

        public override void FixedUpdate(FSM<GameLauncher> fsm, float fTick)
        {
        }

        public override void Update(FSM<GameLauncher> fsm, float fTick)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Engine.Instance.logger.Log(ELogType.Debug, "Game", "Send Event Test");
                EventTest e = new EventTest(){str = "StateEnd"};
                Engine.Instance.eventMgr.SendEvent(e);
            }
        }

        public override void LateUpdate(FSM<GameLauncher> fsm, float fTick)
        {
        }
    }
}