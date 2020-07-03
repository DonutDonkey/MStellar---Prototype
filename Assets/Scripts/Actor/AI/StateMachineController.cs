using UnityEngine;

/**
 * Mockup State Machine Singleton Controller 
 */
namespace Actor.AI {
    public class StateMachineController : MonoBehaviour {
        public FiniteStateMachine StateMachine { get; }

        private void FixedUpdate() => StateMachine.Tick();

        public void ChangeState(State state) => StateMachine.ChangeState(state);
    }
}
