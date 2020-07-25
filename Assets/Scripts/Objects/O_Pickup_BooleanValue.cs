using Data.Values;
using GUI;
using UnityEngine;

namespace Objects {
    public class O_Pickup_BooleanValue : MonoBehaviour {
        [SerializeField] private BooleanValue value;

        [SerializeField] private string actorName;

        private void OnTriggerEnter(Collider other) {
            if (!other.gameObject.name.Equals(actorName)) return;
            
            value.value = true;
            
            Ui_Player_Effects.PlayGuiItemAnimation();
            S_Manager_AudioManager.PlayClip("ItemPickup");
            
            gameObject.SetActive(false);
        }
    }
}