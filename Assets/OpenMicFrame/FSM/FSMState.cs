namespace Framework.FSM
{
    public abstract class FSMState<T> where T : class, new()
    {
        public abstract int StateType();
        public virtual void Enter(FSM<T> fsm)
        {

        }
        public virtual void Exit(FSM<T> fsm)
        {

        }
        public virtual void FixedUpdate(FSM<T> fsm, float fTick)
        {

        }
        public virtual void Update(FSM<T> fsm, float fTick)
        {

        }
        public virtual void LateUpdate(FSM<T> fsm, float fTick)
        {

        }
    }
}