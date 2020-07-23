using Actor.AI;
using UnityEngine;

namespace Actor.Enemy.AI {
    public class EnemyIncentives : StateMachineController {
        private Transform _targetTransform;
        public Transform TargetTransform => _targetTransform;
        
        protected override void Awake() {
            base.Awake();

            _targetTransform = GameObject.Find("Player").GetComponent<Transform>();
        }
    }
}
