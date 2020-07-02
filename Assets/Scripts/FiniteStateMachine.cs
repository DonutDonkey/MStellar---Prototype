using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine {
    private IState _currentState;
    
    private List<Transition> _transitions; 
    
    /**
     * Implements Default State
     */
    public void Start(IState state) => SetState(state);

    public void Tick() {
        
        _currentState?.Tick();
    }

    public void SetState(IState state) {
        if(_currentState.Equals(state))
            return;
        
        _currentState?.OnExit();
        _currentState = state;
        _currentState?.OnEnter();
    }
}
