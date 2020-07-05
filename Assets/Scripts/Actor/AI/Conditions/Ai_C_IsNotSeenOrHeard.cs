using Actor.Player;
using Data.Values;
using UnityEngine;

namespace Actor.AI.Conditions {
    public class Ai_C_IsNotSeenOrHeard : Condition {
        [SerializeField] private FloatValue fieldOfView;
        [SerializeField] private FloatValue viewRadius;

        [SerializeField] private Transform thisTransform;
        [SerializeField] private Transform otherTransform;

        [SerializeField] private LayerMask viewMask;
        
        [SerializeField] private PlayerInputHandler playerInputHandler;
        
        public override bool IsTrue() => (!IsInFov() && !CheckIfMadeNoise()) 
            ? true 
            : false;

        private bool IsInFov() => 
            (Vector3.Distance(thisTransform.position, otherTransform.position) < viewRadius) 
                ? true 
                : false;

        private float Angle() => Vector3.Angle(otherTransform.position - thisTransform.position, thisTransform.forward);
        
        private bool CheckIfMadeNoise() => 
            (playerInputHandler.IsJumping() || playerInputHandler.GetAttackButton()) 
                ? true 
                : false;
    }
}
