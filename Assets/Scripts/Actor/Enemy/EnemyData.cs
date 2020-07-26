using System.Collections;
using Actor.Enemy.AI;
using Data.Values;
using UnityEngine;

namespace Actor.Enemy
{
    public class EnemyData : ActorData {
        [SerializeField] private FloatValue enemyCooldown;

        [SerializeField] private float damageThreshold;
        
        private EnemyIncentives _enemyIncentives;
        private FloatValue _health;
        
        private float _ogDamageTreshold;

        private bool _isHurt;
        public  bool IsHurt { get => _isHurt; set => _isHurt = value; }
        
        public FloatValue EnemyCooldown => enemyCooldown;

        protected override void Awake() {
            base.Awake();
            // Alternative option?
            // _health = ScriptableObject.CreateInstance<FloatValue>();
            // _health.value = Health.value;
            _health = Instantiate(Health);
            Health = _health;

            _enemyIncentives = GetComponent<EnemyIncentives>();
            _ogDamageTreshold = damageThreshold;
        }

        public void TakeDamage(float value, ActorData source) {
            Debug.Log("EnemyData.TakeDamage : value:" + value + " source:" + source.gameObject.name);
            base.TakeDamage(value);

            damageThreshold -= value;
            
            StartCoroutine(IsHurtState());

            if (!(damageThreshold <= 0) || source.gameObject.name.Equals(gameObject.name)) return;
            
            _enemyIncentives.LookForNewTarget(source.GetComponent<Transform>());
            damageThreshold = _ogDamageTreshold;
        }

        private IEnumerator IsHurtState() {
            IsHurt = true;
            
            yield return new WaitForSeconds(5f);

            IsHurt = false;
        }
    }
}