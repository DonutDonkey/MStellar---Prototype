using System;
using System.Collections;
using Actor.Enemy;
using Actor.Enemy.AI;
using Data.Values;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Actor.AI.States {
    public class Ai_S_MeleeAggro : State{
        [SerializeField] private EnemyDebug debugInfo;
        
        [SerializeField] private FloatValue enemyDamage;
        
        private EnemyIncentives _enemyIncentives;

        private NavMeshAgent _navMeshAgent;
        
        private ActorData _targetData;
        
        private float _movePoints;
        private float _dodgePoints;
        private float _cooldownTimer;
        
        public EnemyDebug DebugInfo { get => debugInfo; set => debugInfo = value; }
        
        private float Cooldown { get; set; }
        
        private readonly int _aggro = Animator.StringToHash("Aggro");

        private void Awake() {
            Cooldown = (GetComponentInParent<ActorData>() is EnemyData enemyData)
                ? enemyData.EnemyCooldown.value
                : 0;
            
            _navMeshAgent = GetComponentInParent<NavMeshAgent>();
            _enemyIncentives = GetComponentInParent<EnemyIncentives>();
        }

        private void Start() => _targetData = _enemyIncentives.TargetTransform.GetComponent<ActorData>();

        public override void Enter() {
#if UNITY_EDITOR
            DebugInfo.DebugText.text = GetType().ToString();
            DebugInfo.DebugText.color = Color.red;
            DebugInfo.HearingColor = Color.red;
#endif
            var anim = GetComponentInParent<Animator>();
            anim.SetBool(_aggro, true);
        }

        public override void Tick() {
            CalculateMovement();
            
            if( _cooldownTimer <= 0 && CheckForTargetInAttackDistance() )
                PreAttack();
            
            _cooldownTimer -= Time.deltaTime;
        }

        private void CalculateMovement() {
            if (_movePoints <= 0 || _navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance) {
                _navMeshAgent.SetDestination(_enemyIncentives.TargetTransform.position);
                
                if ( Math.Abs(_dodgePoints % 5 ) < 1 )
                    _navMeshAgent.SetDestination(transform
                        .TransformPoint(Vector3.right * Random.Range(-5, 5)));
                
                _movePoints = 50;
                _dodgePoints++;
            }
            _movePoints--;
        }

        private void PreAttack() {
            GetComponentInParent<Animator>().Play("Attack");
            _navMeshAgent.velocity /= 2;
            _navMeshAgent.transform.LookAt(_enemyIncentives.TargetTransform.position);
            
            StartCoroutine(DoAfter(0.5f));
            
            _cooldownTimer = Cooldown;
        }
        
        private IEnumerator DoAfter(float time) {
            yield return new WaitForSeconds(time);
            
            if( CheckForTargetInAttackDistance()  && GetComponentInParent<Animator>())
                Attack();
        }
        
        private bool CheckForTargetInAttackDistance() => 
            Vector3.Distance(transform.position, _enemyIncentives.TargetTransform.position) < 3f;

        private void Attack() {
            var ad = _enemyIncentives.TargetTransform.GetComponent<ActorData>();
            if (ad.IsDead()) _enemyIncentives.LookForDefaultTarget();

            if (ad is EnemyData ed) {
                ed.TakeDamage(enemyDamage.value, GetComponentInParent<ActorData>());
                ed.gameObject.GetComponent<Animator>().Play("Hurt");
            } else 
                ad.TakeDamage(enemyDamage.value);
        }

        public override void Exit() { }

        #region DebugInfo

        private readonly Color _debugC = new Color(1,0.5f,0.5f);
        private void OnDrawGizmos() {
            if ( _navMeshAgent == null )
                return;
#if UNITY_EDITOR
            Handles.color = _debugC;
            Handles.DrawAAPolyLine(_navMeshAgent.path.corners);
            
            Gizmos.DrawWireCube(_navMeshAgent.pathEndPosition, Vector3.one);
#endif
        }

        #endregion
    }
}