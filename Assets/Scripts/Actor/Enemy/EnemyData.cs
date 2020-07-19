using Data.Values;
using UnityEngine;

namespace Actor.Enemy
{
    public class EnemyData : ActorData {
        [SerializeField] private FloatValue enemyCooldown;

        public FloatValue EnemyCooldown => enemyCooldown;

        private FloatValue _health;

        protected override void Awake() {
            base.Awake();
            // Alternative option?
            // _health = ScriptableObject.CreateInstance<FloatValue>();
            // _health.value = Health.value;
            _health = Instantiate(Health);
            Health = _health;
        }
    }
}