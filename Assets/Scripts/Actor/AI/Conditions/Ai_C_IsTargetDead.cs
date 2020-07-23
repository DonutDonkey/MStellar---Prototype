using Actor.Enemy.AI;

namespace Actor.AI.Conditions {
    public class Ai_C_IsTargetDead : Condition {
        private ActorData _targetData;
        
        private void Start() => 
            _targetData = GetComponentInParent<EnemyIncentives>().TargetTransform.GetComponent<ActorData>();

        public override bool IsTrue() => _targetData.IsDead();
    }
}