using UnityEngine;

namespace Actor.AI.Conditions {
    public class Ai_C_IsDead : Condition {
        [SerializeField] private ActorData actorData;

        private void Awake() {
            actorData = GetComponentInParent<ActorData>();
        }

        public override bool IsTrue() => actorData.IsDead();
    }
}