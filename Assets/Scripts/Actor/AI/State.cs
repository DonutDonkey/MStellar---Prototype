using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Actor.AI {
    public abstract class State : MonoBehaviour, IState {
        [SerializeField] private List<Transition> transitions = new List<Transition>();

        public IState ProcessTransitions() => 
            (from transition 
                in transitions 
                where transition.ShouldTransition()
                select transition.NextState).FirstOrDefault();

        public abstract void Enter();

        public abstract  void Tick();

        public abstract void Exit();
    }
}
