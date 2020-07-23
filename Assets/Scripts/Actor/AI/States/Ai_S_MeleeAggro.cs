using System.Collections;
using Actor.Enemy;
using Actor.Enemy.AI;
using Data.Values;
using UnityEngine;
using UnityEngine.AI;

namespace Actor.AI.States {
    public class Ai_S_MeleeAggro : State{
        [SerializeField] private EnemyDebug debugInfo;
        [SerializeField] private FloatValue enemyDamage;
        
        public EnemyDebug DebugInfo { get => debugInfo; set => debugInfo = value; }
        
        private ActorData _targetData;

        private NavMeshAgent _navMeshAgent;

        private Transform _targetTransform;
        
        private float _cooldownTimer = 0f;
        private float Cooldown { get; set; }
        
        private readonly int _aggro = Animator.StringToHash("Aggro");

        private void Awake() {
            Cooldown = (GetComponentInParent<ActorData>() is EnemyData enemyData)
                ? enemyData.EnemyCooldown.value
                : 0;

            _navMeshAgent = GetComponent<NavMeshAgent>();
            _targetTransform = GameObject.Find("Player").GetComponent<Transform>();
            _targetData = _targetTransform.GetComponent<ActorData>();

            
        }

        public override void Enter() {
            DebugInfo.DebugText.text = GetType().ToString();
            DebugInfo.DebugText.color = Color.red;
            DebugInfo.HearingColor = Color.red;
            
            _navMeshAgent = GetComponentInParent<NavMeshAgent>();
            var anim = GetComponentInParent<Animator>();
            anim.SetBool(_aggro, true);
        }

        public override void Tick() {
            _navMeshAgent.SetDestination(_targetTransform.position);
            
            if( _cooldownTimer <= 0 && CheckForTargetInAttackDistance() )
                PreAttack();
            
            _cooldownTimer -= Time.deltaTime;
        }
        
        private void PreAttack() {
            GetComponentInParent<Animator>().Play("Attack");
            _navMeshAgent.velocity /= 2;
            
            StartCoroutine(DoAfter(0.5f));
            
            _cooldownTimer = Cooldown;
        }
        
        private IEnumerator DoAfter(float time) {
            yield return new WaitForSeconds(time);
            
            if( CheckForTargetInAttackDistance()  && GetComponentInParent<Animator>())
                Attack();
        }
        
        private bool CheckForTargetInAttackDistance() => 
            Vector3.Distance(transform.position, _targetTransform.position) < 3f;

        private void Attack() => _targetData.TakeDamage(enemyDamage.value);

        public override void Exit() { }
    }
}