using Data.GameObjectsData;
using Data.Values;
using GUI;
using UnityEngine;

namespace Objects {
    public class O_Pickup_WeaponAmmo : MonoBehaviour {
        [SerializeField] private FloatValue currentAmmo;
        [SerializeField] private WeaponData weaponData;
        
        [SerializeField] private string actorName;

        [SerializeField] private float value;

        private void OnTriggerEnter(Collider other) {
            if (!other.gameObject.name.Equals(actorName)) return;
            if (currentAmmo.value.Equals(weaponData.MaxAmmunition)) return;

            currentAmmo.value = ((currentAmmo.value) + value > weaponData.MaxAmmunition.value)
                ? weaponData.MaxAmmunition.value
                : currentAmmo.value + value;
            
            Ui_Player_Effects.PlayGuiItemAnimation();
            S_Manager_AudioManager.PlayClip("AmmoPickup");
            
            gameObject.SetActive(false);
        }
    }
}