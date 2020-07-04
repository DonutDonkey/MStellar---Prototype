namespace Actor.AI {
    public class FiniteStateMachine {
        public FiniteStateMachine(IState currentState) {
            CurrentState = currentState;
            ChangeState(CurrentState);
        }

        private IState CurrentState { get; set; }

        private void ChangeState(IState state) {
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
