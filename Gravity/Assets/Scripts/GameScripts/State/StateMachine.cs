namespace StateMachine
{
    public class StateMachine<T>
    {
        public State<T> CurrentState { get; private set; }
        public T Owner;

        public StateMachine(T _owner)
        {
            Owner = _owner;
            CurrentState = null;
        }

        public void ChangeState(State<T> _newstate)
        {
            if (CurrentState != null)
                CurrentState.ExitState(Owner);
            CurrentState = _newstate;
            CurrentState.EnterState(Owner);
        }

        public void Update()
        {
            if (CurrentState != null)
                CurrentState.UpdateState(Owner);
        }
    }

    public abstract class State<T>
    {
        public abstract void EnterState(T _owner);
        public abstract void ExitState(T _owner);
        public abstract void UpdateState(T _owner);
    }
}