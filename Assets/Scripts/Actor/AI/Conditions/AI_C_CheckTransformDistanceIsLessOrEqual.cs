using Data.Values;
using UnityEngine;

namespace Actor.AI.Conditions {
    public class Ai_C_CheckTransformDistanceIsLessOrEqual : Condition {
        [SerializeField] private Transform actorTransform;
        [SerializeField] private Transform targetTransform;

        [SerializeField] private FloatValue value;

        public override bool IsTrue() => Vector3.Distance(actorTransform.position, targetTransform.position) <= value;
    }
}