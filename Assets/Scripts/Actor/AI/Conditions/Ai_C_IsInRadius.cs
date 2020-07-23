using Data.Values;
using UnityEngine;

namespace Actor.AI.Conditions {
    public class Ai_C_IsInRadius : Condition {
        [SerializeField] private FloatValue radius;

        private Transform _thisTransform;
        private Transform _otherTransform;

        private void Awake() {
            _thisTransform = GetComponentInParent<Transform>();
            _otherTransform = GameObject.Find("Player").GetComponent<Transform>();
        }

        public override bool IsTrue() => (CheckDistance() && !IsTargetDead()) ? true : false;

        private bool CheckDistance() {
            return Vector3.Distance(_thisTransform.position, _otherTransform.position) < radius;
        }

        private bool IsTargetDead() => _otherTransform.gameObject.GetComponent<ActorData>().IsDead();
    }
}
