using Actor.AI;
using UnityEngine;

namespace Actor.Enemy.AI {
    public class EnemyIncentives : StateMachineController {
        [SerializeField] private Transform defaultTransform;
        
        private Transform _targetTransform;
        public Transform TargetTransform { get => _targetTransform; set => _targetTransform = value; }

        protected override void Awake() {
            base.Awake();

            _targetTransform = defaultTransform;
        }

        public void LookForNewTarget(Transform target) => TargetTransform = target;
        public void LookForDefaultTarget() => TargetTransform = defaultTransform;
    }
}
