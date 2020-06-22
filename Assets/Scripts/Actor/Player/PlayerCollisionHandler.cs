using System;
using Data.Values;
using UnityEngine;

namespace Actor.Player {
    public class PlayerCollisionHandler : MonoBehaviour {
        [SerializeField] private FloatValue pickupAttractorSpeed;

        private static bool IsTag(Collision obj, string tagName) => obj.gameObject.tag.Equals(tagName);
        private static bool IsTag(Component obj, string tagName) => obj.gameObject.tag.Equals(tagName);
        
        private void OnTriggerStay(Collider other) {
            if ( IsTag(other, "Pickup") ) 
                other.gameObject.transform.localPosition = Vector3.MoveTowards(
                    other.gameObject.transform.localPosition,
                    transform.localPosition,
                    pickupAttractorSpeed.value * Time.deltaTime);
        }
    }
}