namespace Actor.AI {
    public class FiniteStateMachine
    {
        public IState CurrentState { get; private set; }

        public void ChangeState(IState state) {
            CurrentState?.Exit();
            CurrentState = state;
            CurrentState?.Enter();
        }

        public void Tick() {
            var nextState = CurrentState.ProcessTransitions();
        
            if(nextState != null)
                ChangeState(nextState);
        
            CurrentState.Tick();
        }
    }
}
