using Actor.Player;
using Data.Values;
using UnityEngine;

namespace Actor.AI.Conditions {
    public class Ai_C_CheckIfCanHear : Condition {
        [SerializeField] private Transform actorTransform;
        [SerializeField] private Transform targetTransform;

        [SerializeField] private FloatValue value;

        private PlayerInputHandler _playerInputHandler;

        private void Awake() => _playerInputHandler = GameObject.Find("Player").GetComponent<PlayerInputHandler>();

        public override bool IsTrue() => (CheckDistance() && CheckIfMadeNoise()) 
            ? true 
            : false;

        private bool CheckDistance() => 
            Vector3.Distance(actorTransform.position, targetTransform.position) <= value;

        private bool CheckIfMadeNoise() => 
            (_playerInputHandler.IsJumping() || _playerInputHandler.GetAttackButton()) 
                ? true 
                : false;
    }
}