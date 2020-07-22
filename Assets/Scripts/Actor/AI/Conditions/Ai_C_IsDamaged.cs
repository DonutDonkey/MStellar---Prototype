using System;

namespace Actor.AI.Conditions {
    public class Ai_C_IsDamaged : Condition {
        private ActorData _enemyData;
        private float _startHealth;

        private void Awake() {
            _enemyData = GetComponentInParent<ActorData>();
            _startHealth = _enemyData.Health.value;
        }

        public override bool IsTrue() => Math.Abs(_enemyData.Health.value - _startHealth) > 0;
    }
}