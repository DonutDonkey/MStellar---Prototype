using Data.Values;
using UnityEngine;

namespace Actor {
    public abstract class ActorData : MonoBehaviour {
        [Header("Values")] 
        
        [SerializeField] private FloatValue maxHealth;
        [SerializeField] private FloatValue health;

        protected FloatValue Health { get => health; set => health = value;}
        protected FloatValue MaxHealth => maxHealth;
        
        protected  Transform ActorPosition { get => _actorPosition; set => _actorPosition = value; }

        private Transform _actorPosition;

        protected virtual void Awake() => _actorPosition = GetComponent<Transform>();

        protected abstract bool IsDead();

        public virtual void TakeDamage(float value) {
            Health -= value;
        }
    }
}