using Data.Values;
using UnityEngine;

namespace Actor {
    public abstract class ActorData : MonoBehaviour {
        [Header("Values")] 
        
        [SerializeField] private FloatValue maxHealth;
        [SerializeField] private FloatValue health;

        private     Transform _actorPosition;
        protected   Transform ActorPosition { get; set; }
        
        public FloatValue Health { get => health; protected set => health = value; }
        public FloatValue MaxHealth => maxHealth;

        protected internal bool IsDead() => Health <= 0f;

        protected virtual void Awake() => _actorPosition = GetComponent<Transform>();

        public virtual void TakeDamage(float value) {
            Debug.Log("ActorData.TakeDamage");
            
            if( !IsDead() )
                Health -= value;
        }
    }
}