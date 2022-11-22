using System;
using Framework.FSM;
using Framework.FSMStates;
using Framework.Singleton;
using UnityEngine;

namespace Framework.Game
{

    /// <summary>
    /// 游戏状态
    /// </summary>
    public enum EGameState
    {
        None,
        Play,
        End
    }
    
    /// <summary>
    /// 游戏启动类 
    /// </summary>
    public sealed class GameLauncher : MonoSingleton<GameLauncher>
    {
        // 下一个状态
        private EGameState toState = EGameState.None;
        // 有限状态机
        private FSM<GameLauncher> fsm;

        #region 生命周期
        private void Awake()
        {
            Debug.Log("GameLauncher Awake");
            Engine.Instance.Init();
            Engine.Instance.SetUp();
        }

        private void Start()
        {
            Debug.Log("GameLauncher Start");
            fsm = new FSM<GameLauncher>(this);
            FSMBuilder.Initialize(fsm);
            
            ChangeState(EGameState.Play, true);
        }

        private void OnDestroy()
        {
            fsm?.Destroy();
        }

        private void Update()
        {
            fsm?.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            fsm?.FixedUpdate(Time.fixedDeltaTime);
        }

        private void LateUpdate()
        {
            fsm?.LateUpdate(Time.deltaTime);
        }
        #endregion
        
        /// <summary>
        /// 游戏状态切换
        /// </summary>
        /// <param name="state">切换目标状态</param>
        /// <param name="immediate">是否立即切换</param>
        private void ChangeState(EGameState state, bool immediate = false)
        {
            if (immediate)
            {
                fsm.ChangeState((int)state);
                toState = EGameState.None;
            }
            else
            {
                toState = state;
            }
        }
    }
    
    /// <summary>
    /// 构建状态
    /// </summary>
    internal static class FSMBuilder
    {
        private static readonly Func<FSMState<GameLauncher>>[] states =
        {
            () => new StatePlay(),
            () => new StateEnd()
        };

        public static void Initialize(FSM<GameLauncher> fsm)
        {
            foreach (var t in states)
            {
                fsm.AddState(t.Invoke());
            }
        }
    }
}