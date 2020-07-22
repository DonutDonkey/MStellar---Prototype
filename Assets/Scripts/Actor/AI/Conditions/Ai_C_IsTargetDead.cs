using System;
using UnityEngine;

namespace Actor.AI.Conditions {
    public class Ai_C_IsTargetDead : Condition {
        private ActorData _targetData;
        
        private void Awake() => _targetData = GameObject.Find("Player").GetComponent<ActorData>();

        public override bool IsTrue() => _targetData.IsDead();
    }
}