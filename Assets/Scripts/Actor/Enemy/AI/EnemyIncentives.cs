using System;
using Data.Values;
using UnityEngine;

namespace Actor.Enemy.AI {
    public class EnemyIncentives : MonoBehaviour {
        [SerializeField] private FloatValue hearingRadius;

        public FloatValue HearingRadius => hearingRadius;

        private FiniteStateMachine _finiteStateMachine;

        private void Awake() {
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
