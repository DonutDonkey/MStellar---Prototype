using System;
using System.Collections.Generic;
using Data.Values;
using UnityEngine;

namespace Actor.Enemy.AI {
    public class EnemyIncentives : MonoBehaviour {
        [SerializeField] private FloatValue hearingRadius;
        
        [SerializeField] private Transform player;
        
        public FloatValue HearingRadius => hearingRadius;

        // public FiniteStateMachine finiteStateMachine;

        private void Awake() {
        }

        // private void FixedUpdate() => finiteStateMachine.Tick();
    }
}
