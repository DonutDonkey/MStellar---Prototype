using Data.Values;
using UnityEngine;

namespace Actor.AI.Conditions {
    public class Ai_C_IsInFov : Condition {
        [SerializeField] private FloatValue fieldOfView;
        [SerializeField] private FloatValue viewRadius;

        [SerializeField] private Transform thisTransform;
        [SerializeField] private Transform otherTransform;

        [SerializeField] private LayerMask viewMask;
        
        public override bool IsTrue() {
            if (!(Vector3.Distance(thisTransform.position, otherTransform.position) < viewRadius)) 
                return false;
            if (!(Angle() < fieldOfView.value * 0.5f)) 
                return false;
            
            return !Physics.Linecast(thisTransform.position, otherTransform.position, viewMask);
        }
        
        private float Angle() => Vector3.Angle(otherTransform.position - thisTransform.position, thisTransform.forward);
    }
}
