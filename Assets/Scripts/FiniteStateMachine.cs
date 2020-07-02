using System.Collections.Generic;
using System.Linq;

public class FiniteStateMachine {
    private IState _currentState;
    
    private readonly List<Transition> _transitions;

    public FiniteStateMachine(List<Transition> transitions) => _transitions = transitions;

    /**
     * Implements Default State
     */
    public void Start(IState state) => SetState(state);

    public void Tick() {
        var transaction = getTransition();
        
        if( transaction != null )
            SetState(transaction.To);
        
        _currentState?.Tick();
    }

    private void SetState(IState state) {
        if(_currentState.Equals(state))
            return;
        
        _currentState?.OnExit();
        _currentState = state;
        _currentState?.OnEnter();
    }

    private Transition getTransition() => 
        _transitions.FirstOrDefault(transition => transition.Condition() 
                                                  && transition.From.Equals(_currentState));
}
