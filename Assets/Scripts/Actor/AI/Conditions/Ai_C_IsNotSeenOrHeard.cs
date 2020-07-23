using Actor.Player;
using Data.Values;
using UnityEngine;

namespace Actor.AI.Conditions {
    public class Ai_C_IsNotSeenOrHeard : Condition {
        [SerializeField] private FloatValue viewRadius;
    
        [SerializeField] private LayerMask viewMask;
        
        private Transform _thisTransform;
        private Transform _otherTransform;
    
        private PlayerInputHandler _playerInputHandler;
        private void Awake() {
            _thisTransform = GetComponentInParent<Transform>();
            _otherTransform = GameObject.Find("Player").GetComponent<Transform>();
            _playerInputHandler = GameObject.Find("Player").GetComponent<PlayerInputHandler>();
        }
        
        public override bool IsTrue() => (!IsInFov() && !CheckIfMadeNoise()) 
            ? true 
            : false;

        private bool IsInFov() => 
            (Vector3.Distance(_thisTransform.position, _otherTransform.position) < viewRadius) 
                ? true 
                : false;

        private float Angle() => Vector3.Angle(_otherTransform.position - _thisTransform.position, _thisTransform.forward);
        
        private bool CheckIfMadeNoise() => 
            (_playerInputHandler.IsJumping() || _playerInputHandler.GetAttackButton() || !_playerInputHandler.IsGrounded()) 
                ? true 
                : false;
    }
}
