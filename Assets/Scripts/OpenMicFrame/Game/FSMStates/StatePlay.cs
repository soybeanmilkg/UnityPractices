// /**
//  * File Name: StatePlay.cs
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
    /// 开始状态/运行状态
    /// </summary>
    public class StatePlay : FSMState<GameLauncher>
    {
        public override int StateType()
        {
            return (int)EGameState.Play;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public override void Enter(FSM<GameLauncher> fsm)
        {
            Engine.Instance.logger.Log(ELogType.Debug, "Game",
                "<color=cyan>------------------StatePlay Enter-----------------</color>");
            Engine.Instance.eventMgr.AddEvent<EventTest>(OnEventTest);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public override void Exit(FSM<GameLauncher> fsm)
        {
            Engine.Instance.logger.Log(ELogType.Debug, "Game",
                "<color=cyan>------------------StatePlay Exit-----------------</color>");
            
            Engine.Instance.eventMgr.RemoveEvent<EventTest>(OnEventTest);
        }

        public override void FixedUpdate(FSM<GameLauncher> fsm, float fTick)
        {
        }

        public override void Update(FSM<GameLauncher> fsm, float fTick)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Engine.Instance.logger.Log(ELogType.Debug, "Game", "Change StatePlay to StateEnd");
                fsm.ChangeState((int)EGameState.End);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Engine.Instance.logger.Log(ELogType.Debug, "Game", "Send Event Test");
                EventTest e = new EventTest(){str = "StatePlay"};
                Engine.Instance.eventMgr.SendEvent(e);
            }
        }

        public override void LateUpdate(FSM<GameLauncher> fsm, float fTick)
        {
        }

        #region Event

        private void OnEventTest(EventTest t)
        {
            Engine.Instance.logger.LogF(ELogType.Debug, "Game", "Event Test: {0}", t.str);
        }

        #endregion
    }
}