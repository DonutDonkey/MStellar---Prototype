namespace Actor.AI {
    public interface IState {
        IState ProcessTransitions();
        void Enter();
        void Tick();
        void Exit();
    }
}
