using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Actor.AI {
    public class State : MonoBehaviour, IState
    {
        [SerializeField] private List<Transition> transitions = new List<Transition>();

        public IState ProcessTransitions() => 
            (from transition 
                in transitions 
                where transition.ShouldTransition()
                select transition.NextState).FirstOrDefault();

        public void Enter() {
            throw new System.NotImplementedException();
        }

        public void Tick() {
            throw new System.NotImplementedException();
        }

        public void Exit() {
            throw new System.NotImplementedException();
        }
    }
}
