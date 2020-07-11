using Data.Values;
using UnityEngine;

namespace Actor.Player {
    public class PlayerData : ActorData {
        [Header("Values")]
        
        [SerializeField] private FloatValue maxArmor;
        [SerializeField] private FloatValue armor;

        private FloatValue MaxArmor => maxArmor;

        public FloatValue Armor { get => armor; set => armor = value; }

        public override void TakeDamage(float value) {
            Debug.Log("PlayerData.TakeDamage - START");
            
            if (Armor > 0) {
                Debug.Log("PlayerData.TakeDamage - SEES ARMOR SHIT");
                Health -= value / Armor;
                Armor -= value;
            } else {
                Health -= value;
            }

            ConvertToTotal();

            if(IsDead())
                Debug.Log("Actor.Player isDead");
        }

        private void ConvertToTotal() {
            Health.value = ( Health.value < 0 ) ? 0f : Health.value;
            Armor.value = ( Armor.value < 0 ) ? 0f : Armor.value;
        }

        public void IncreaseHealth(float v) => Health = (Health + v) > MaxHealth
            ? MaxHealth
            : Health + v;

        public void IncreaseArmor(float v) => Armor = (Armor + v) > MaxArmor
            ? MaxArmor
            : MaxArmor + v;
    }
}