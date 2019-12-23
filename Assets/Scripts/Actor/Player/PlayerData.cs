using Data.Values;
using UnityEngine;

namespace Actor.Player {
    public class PlayerData : ActorData {
        [Header("Values")]
        
        [SerializeField] private FloatValue maxArmor;
        [SerializeField] private FloatValue armor;

        private FloatValue MaxArmor => maxArmor;

        public FloatValue Armor { get => armor; set => armor = value; }

        protected override bool IsDead() => Health > 0f;

        public override void TakeDamage(float value) {
            Health -= value / Armor;
            Armor -= value;
        }

        public void IncreaseHealth(float v) => Health = (Health + v) > MaxHealth
            ? MaxHealth
            : Health + v;

        public void IncreaseArmor(float v) => Armor = (Armor + v) > MaxArmor
            ? MaxArmor
            : MaxArmor + v;
    }
}