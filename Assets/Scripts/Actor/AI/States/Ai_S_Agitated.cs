using Actor.Enemy.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Actor.AI.States {
    public class Ai_S_Agitated : State {
        [SerializeField] private EnemyDebug debugInfo;

        private NavMeshAgent _navMeshAgent;

        private Vector3 _originalPosition;
        public EnemyDebug DebugInfo { get => debugInfo; set => debugInfo = value; }

        private void Awake() => _originalPosition = GetComponentInParent<Transform>().position;

        public override void Enter() {
            DebugInfo.DebugText.text = GetType().ToString();
            DebugInfo.DebugText.color = Color.yellow;
            DebugInfo.HearingColor = Color.yellow;

            _navMeshAgent = GetComponentInParent<NavMeshAgent>();
            var anim = GetComponentInParent<Animator>();
        }

        public override void Tick() {
            _navMeshAgent.SetDestination(_originalPosition);
            
            if( Vector3.Distance(transform.position, _originalPosition) > 1f ) return;
            
            var anim = GetComponentInParent<Animator>();
            anim.SetBool("Aggro", false);
        }

        public override void Exit() {
            // throw new System.NotImplementedException();
        }
    }
}