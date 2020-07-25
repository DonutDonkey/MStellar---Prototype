using Actor.Enemy;
using UnityEngine;

namespace Actor.AI.Conditions {
    public class Ai_C_IsHurt : Condition {
        [SerializeField] private ActorData actorData;
        
        public override bool IsTrue() => ((EnemyData)actorData).isHurt;
    }
}