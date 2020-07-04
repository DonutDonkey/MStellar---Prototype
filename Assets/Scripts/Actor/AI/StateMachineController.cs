using UnityEngine;

namespace Actor.AI {
    public class StateMachineController : MonoBehaviour {
        [SerializeField] private State startingState;

        private FiniteStateMachine _stateMachine;

        private void FixedUpdate() => _stateMachine.Tick();

        protected virtual void Awake() => _stateMachine = new FiniteStateMachine(startingState);
    }
}
