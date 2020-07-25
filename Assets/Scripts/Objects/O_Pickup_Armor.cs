using Actor;
using Actor.Player;
using GUI;
using UnityEngine;

namespace Objects {
    class O_Pickup_Armor : O_Pickup_ActorData {
        [SerializeField] private float pickupValue;
        
        private void PickupAction(PlayerData data) {
            if (data == null) return;
            if(data.Armor.value.Equals(data.MaxArmor.value)) return;
            
            data.Armor.value = (data.Armor.value + pickupValue > data.MaxArmor)
                ? data.MaxArmor.value
                : data.Armor.value + pickupValue;
            
            Ui_Player_Effects.PlayGuiArmorAnimation();
            S_Manager_AudioManager.PlayClip("ItemPickup");
            
            gameObject.SetActive(false);
        }

        protected override void PickupAction(ActorData ad) => PickupAction(ad as PlayerData);
    }
}