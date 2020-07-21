using Actor.Enemy.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Actor.AI.States {
    public class Ai_S_Dead : State {
        [SerializeField] private EnemyDebug debugInfo;
        
        public EnemyDebug DebugInfo { get => debugInfo; set => debugInfo = value; }
        
        private NavMeshAgent _navMeshAgent;
        
        private static readonly int IsDead = Animator.StringToHash("IsDead");
        private static readonly int Aggro = Animator.StringToHash("Aggro");

        public override void Enter() {
            DebugInfo.DebugText.text = GetType().ToString();
            DebugInfo.DebugText.color = Color.grey;
            DebugInfo.HearingColor = Color.gray;
            
            _navMeshAgent = GetComponentInParent<NavMeshAgent>();
            _navMeshAgent.velocity = Vector3.zero;
            _navMeshAgent.isStopped = true;
            
            GetComponentInParent<Animator>().SetBool(Aggro, false);
            GetComponentInParent<Animator>().SetBool(IsDead, true);

            GetComponentInParent<CapsuleCollider>().enabled = false;

            S_GameManager_LocalObserver.Instance.EnemyCountAlive++;
        }

        public override void Tick() { }

        public override void Exit() { }
    }
}