using Actor.Enemy.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Actor.AI.States {
    public class Ai_S_Aggro : State {
        [SerializeField] private EnemyDebug debugInfo;

        private NavMeshAgent _navMeshAgent;
        public EnemyDebug DebugInfo { get => debugInfo; set => debugInfo = value; }

        public override void Enter() {
            DebugInfo.DebugText.text = GetType().ToString();
            DebugInfo.DebugText.color = Color.red;
            DebugInfo.HearingColor = Color.red;

            _navMeshAgent = GetComponentInParent<NavMeshAgent>();
            var anim = GetComponentInParent<Animator>();
            anim.SetBool("Aggro", true);
        }

        public override void Tick() => _navMeshAgent.SetDestination(GameObject.Find("Player").transform.position);

        public override void Exit() { }
    }
}