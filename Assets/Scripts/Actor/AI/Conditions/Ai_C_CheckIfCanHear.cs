using Actor.Player;
using Data.Values;
using UnityEngine;
using UnityEngine.Serialization;

namespace Actor.AI.Conditions {
    public class Ai_C_CheckIfCanHear : Condition {
        [SerializeField] private Transform actorTransform;
        [SerializeField] private Transform targetTransform;

        [SerializeField] private FloatValue value;

        [SerializeField] private PlayerInputHandler playerInputHandler;

        public override bool IsTrue() => (CheckDistance() && CheckIfMadeNoise()) 
            ? true 
            : false;

        private bool CheckDistance() => 
            Vector3.Distance(actorTransform.position, targetTransform.position) <= value;

        private bool CheckIfMadeNoise() => 
            (playerInputHandler.IsJumping() || playerInputHandler.GetAttackButton()) 
                ? true 
                : false;
    }
}