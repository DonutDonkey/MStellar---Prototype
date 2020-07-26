using System.Collections;
using Actor.Enemy.AI;
using Data.Values;
using UnityEngine;

namespace Actor.Enemy
{
    public class EnemyData : ActorData {
        [SerializeField] private FloatValue enemyCooldown;

        [SerializeField] private float damageThreshold;
        public FloatValue EnemyCooldown => enemyCooldown;

        private bool _isHurt;
        public  bool IsHurt { get => _isHurt; set => _isHurt = value; }
        
        private FloatValue _health;

        private EnemyIncentives _enemyIncentives;

        protected override void Awake() {
            base.Awake();
            // Alternative option?
            // _health = ScriptableObject.CreateInstance<FloatValue>();
            // _health.value = Health.value;
            _health = Instantiate(Health);
            Health = _health;

            _enemyIncentives = GetComponent<EnemyIncentives>();
        }

        public void TakeDamage(float value, ActorData source) {
            base.TakeDamage(value);
            
            StartCoroutine(IsHurtState());

            if (value > damageThreshold && !source.gameObject.name.Equals(gameObject.name))
                _enemyIncentives.LookForNewTarget(source.GetComponent<Transform>());
        }

        private IEnumerator IsHurtState() {
            IsHurt = true;
            
            yield return new WaitForSeconds(5f);

            IsHurt = false;
        }
    }
}