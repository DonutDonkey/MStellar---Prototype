using System;
using Actor.Enemy.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Actor.AI.States {
    public class Ai_S_Dead : State {
        [SerializeField] private EnemyDebug debugInfo;

        private AudioSource _audioSource;
        
        private NavMeshAgent _navMeshAgent;
        public EnemyDebug DebugInfo { get => debugInfo; set => debugInfo = value; }
        
        private static readonly int IsDead = Animator.StringToHash("IsDead");
        private static readonly int Aggro = Animator.StringToHash("Aggro");

        private void Awake() => _audioSource = GetComponent<AudioSource>();

        public override void Enter() {
            GetComponentInParent<Animator>().SetBool(IsDead, true);
            _audioSource.Play();
#if UNITY_EDITOR
            DebugInfo.DebugText.text = GetType().ToString();
            DebugInfo.DebugText.color = Color.grey;
            DebugInfo.HearingColor = Color.gray;
#endif            
            _navMeshAgent = GetComponentInParent<NavMeshAgent>();
            _navMeshAgent.velocity = Vector3.zero;
            _navMeshAgent.isStopped = true;
            _navMeshAgent.height = 0;
            _navMeshAgent.radius = 0;
            
            GetComponentInParent<Animator>().SetBool(Aggro, false);

            GetComponentInParent<CapsuleCollider>().enabled = false;

            S_GameManager_LocalObserver.Instance.EnemyCountAlive++;
        }

        public override void Tick() { }

        public override void Exit() { }
    }
}