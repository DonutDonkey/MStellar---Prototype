using Actor.AI;
using Data.Values;
using UnityEngine;

namespace Actor.Enemy.AI {
    public class EnemyIncentives : StateMachineController {
        [SerializeField] private FloatValue hearingRadius;

        private EnemyDebug _enemyDebug;

        private Transform _targetTransform;
        public FloatValue HearingRadius => hearingRadius;

        public Transform TargetTransform => _targetTransform;
        
        protected override void Awake() {
            base.Awake();
            _enemyDebug = GetComponent<EnemyDebug>();
            
            _targetTransform = GameObject.Find("Player").GetComponent<Transform>();
        }
    }
}
