using System;

public class Transition {
    private readonly IState _from;
    private readonly IState _to;
    
    private readonly Func<bool> _condition;
    
    public IState From => _from;
    public IState To => _to;

    public Func<bool> Condition => _condition;
    
    public Transition(IState @from, IState to, Func<bool> condition) {
        _from = @from;
        _to = to;
        _condition = condition;
    }
}
