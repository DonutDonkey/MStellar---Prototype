using Data.Values;
using UnityEngine;

namespace Actor.AI.Conditions {
    public class Ai_C_IsInFov : Condition {
        [SerializeField] private FloatValue fieldOfView;
        [SerializeField] private FloatValue viewRadius;
        
        [SerializeField] private LayerMask viewMask;

        private Transform _thisTransform;
        private Transform _otherTransform;
        
        private void Awake() {
            _thisTransform = GetComponentInParent<Transform>();
            _otherTransform = GameObject.Find("Player").GetComponent<Transform>();
        }

        public override bool IsTrue() {
            if (!(Vector3.Distance(_thisTransform.position, _otherTransform.position) < viewRadius)) 
                return false;
            if (!(Angle() < fieldOfView.value * 0.5f)) 
                return false;
            
            return !Physics.Linecast(_thisTransform.position, _otherTransform.position, viewMask);
        }
        
        private float Angle() => Vector3.Angle(_otherTransform.position - _thisTransform.position, _thisTransform.forward);
    }
}
