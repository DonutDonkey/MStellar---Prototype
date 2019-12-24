using Data.Values;
using UnityEngine;

namespace Actor.Player {
    public class PlayerCollisionHandler : MonoBehaviour {
        [SerializeField] private FloatValue pickupAttractorSpeed;
        
        private void OnTriggerStay(Collider other) {
            if (other.gameObject.tag.Equals("Pickup")) 
                other.gameObject.transform.localPosition = Vector3.MoveTowards(
                    other.gameObject.transform.localPosition,
                    transform.localPosition,
                    pickupAttractorSpeed.value * Time.deltaTime);
        }
    }
}