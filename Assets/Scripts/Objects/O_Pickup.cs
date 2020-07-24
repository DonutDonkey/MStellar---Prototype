using Actor;
using UnityEngine;

namespace Objects {
    public abstract class O_Pickup : MonoBehaviour {
        protected abstract void PickupAction(ActorData ad);
        
        private void OnTriggerEnter(Collider other) => PickupAction(other.gameObject.GetComponent<ActorData>());
    }
}
