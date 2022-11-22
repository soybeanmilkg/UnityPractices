using Framework.FSM;
using Framework.Game;
using UnityEngine;

namespace Framework.FSMStates
{
    public class StatePlay :FSMState<GameLauncher>
    {
        public override int StateType()
        {
            return (int)EGameState.Play;
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        public override void Enter(FSM<GameLauncher> fsm)
        {
            Debug.Log("StatePlay Enter");
        }
        // ReSharper disable Unity.PerformanceAnalysis
        public override void Exit(FSM<GameLauncher> fsm)
        {
            Debug.Log("StatePlay Exit");
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