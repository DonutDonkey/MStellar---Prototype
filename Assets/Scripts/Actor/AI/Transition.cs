using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Actor.AI {
    [Serializable]
    public class Transition : MonoBehaviour {
        [SerializeField] private State nextState = null;
        [SerializeField] private List<Condition> conditions = new List<Condition>();

        public State NextState => nextState;

        public bool ShouldTransition() => conditions.All(condition => condition.IsTrue());
    }
}
