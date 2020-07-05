using Data.Values;
using UnityEngine;

namespace Actor.AI.Conditions {
    public class Ai_C_IsInRadius : Condition {
        [SerializeField] private FloatValue radius;

        [SerializeField] private Transform thisTransform;
        [SerializeField] private Transform otherTransform;


        public override bool IsTrue() => 
            Vector3.Distance(thisTransform.position, otherTransform.position) < radius;
    }
}
