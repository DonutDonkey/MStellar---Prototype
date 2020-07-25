using Actor;
using Actor.Player;
using GUI;
using UnityEngine;

namespace Objects {
    public class O_Pickup_Health : O_Pickup_ActorData {
        [SerializeField] private float pickupValue;
        
        private void PickupAction(PlayerData data) {
            if (data == null) return;
            if(data.Health.value.Equals(data.MaxHealth.value)) return;
            
            data.Health.value = (data.Health.value + pickupValue > data.MaxHealth)
                ? data.MaxHealth.value
                : data.Health.value + pickupValue;
            
            Ui_Player_Effects.PlayGuiHealthAnimation();
            S_Manager_AudioManager.PlayClip("ItemPickup");
            
            gameObject.SetActive(false);
        }

        protected override void PickupAction(ActorData ad) => PickupAction(ad as PlayerData);
    }
}