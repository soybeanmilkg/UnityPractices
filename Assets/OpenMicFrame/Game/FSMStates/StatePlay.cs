// /**
//  * File Name: StatePlay.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/22
//  * Descrption:
//  *
//  */

using Framework.FSM;
using Framework.Game;
using Framework.Log;
using UnityEngine;

namespace OpenMicFrame.FSMStates
{
    /// <summary>
    /// 开始状态/运行状态
    /// </summary>
    public class StatePlay :FSMState<GameLauncher>
    {
        public override int StateType()
        {
            return (int)EGameState.Play;
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        public override void Enter(FSM<GameLauncher> fsm)
        {
            Engine.Instance.logger.Log(ELogType.Debug, "Game", "StatePlay Enter");
        }
        // ReSharper disable Unity.PerformanceAnalysis
        public override void Exit(FSM<GameLauncher> fsm)
        {
            Engine.Instance.logger.Log(ELogType.Debug, "Game", "StatePlay Enter");
        }
        public override void FixedUpdate(FSM<GameLauncher> fsm, float fTick)
        {

        }
        public override void Update(FSM<GameLauncher> fsm, float fTick)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                fsm.ChangeState((int)EGameState.End);
            }
        }
        public override void LateUpdate(FSM<GameLauncher> fsm, float fTick)
        {

        }
    }
}