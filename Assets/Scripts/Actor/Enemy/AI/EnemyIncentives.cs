using Actor.AI;
using Data.Values;
using UnityEngine;

namespace Actor.Enemy.AI {
    public class EnemyIncentives : StateMachineController {
        [SerializeField] private FloatValue hearingRadius;

        private EnemyDebug _enemyDebug;
        
        public FloatValue HearingRadius => hearingRadius;

        protected override void Awake() {
            base.Awake();
            _enemyDebug = GetComponent<EnemyDebug>();
        }

        private void Update() {
        }
    }
}
