using Data.Values;
using UnityEngine;

namespace Actor {
    public abstract class ActorData : MonoBehaviour {
        [Header("Values")] 
        
        [SerializeField] private FloatValue maxHealth;
        [SerializeField] private FloatValue health;

        private     Transform _actorPosition;
        protected   Transform ActorPosition { get; set; }
        
        protected FloatValue Health { get => health; set => health = value; }
        protected FloatValue MaxHealth => maxHealth;

        protected bool IsDead() => Health <= 0f;

        protected virtual void Awake() => _actorPosition = GetComponent<Transform>();

        public virtual void TakeDamage(float value) {
            Health -= value;
        }
    }
}