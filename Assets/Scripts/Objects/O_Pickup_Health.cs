using Actor;
using Actor.Player;
using UnityEngine;

namespace Objects {
    public class O_Pickup_Health : O_Pickup {
        [SerializeField] private float pickupValue;


        private void PickupAction(PlayerData data) {
            if (data == null) return;
            
            data.Health.value = (data.Health.value + pickupValue > data.MaxHealth)
                ? data.MaxHealth.value
                : data.Health.value + pickupValue;
        }

        protected override void PickupAction(ActorData ad) => PickupAction(ad as PlayerData);
    }
}