using System;
using System.Collections;
using Actor.Enemy;
using Actor.Enemy.AI;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Actor.AI.States {
    public class Ai_S_Aggro : State {
        [SerializeField] private EnemyDebug debugInfo;

        [SerializeField] private Transform projectileTransform;
        [SerializeField] private Transform thisTransform;

        [SerializeField] private string projectileTag;
        
        [SerializeField] private LayerMask viewMask;
        
        public EnemyDebug DebugInfo { get => debugInfo; set => debugInfo = value; }
        
        private NavMeshAgent _navMeshAgent;
        
        private GameObject _projectile;

        private EnemyIncentives _enemyIncentives;
        
        private Vector3 _targetPositionOffset;

        private float _movePoints;
        private float _dodgePoints;
        
        private float _cooldownTimer;
        private float Cooldown { get; set; }
        
        private bool _attackAnim;

        private readonly int _aggro = Animator.StringToHash("Aggro");
        
        private void Awake() {
            Cooldown = (GetComponentInParent<ActorData>() is EnemyData enemyData)
                ? enemyData.EnemyCooldown.value
                : 0;
            
            _targetPositionOffset = Vector3.zero;
            _enemyIncentives = GetComponentInParent<EnemyIncentives>();
            _navMeshAgent = GetComponentInParent<NavMeshAgent>();
        }

        public override void Enter() {
            DebugInfo.DebugText.text = GetType().ToString();
            DebugInfo.DebugText.color = Color.red;
            DebugInfo.HearingColor = Color.red;

            var anim = GetComponentInParent<Animator>();
            anim.SetBool(_aggro, true);
        }

        public override void Tick() {
            if( !_attackAnim )
                CalculateMovement();
            
            if(_cooldownTimer <= 0)
                Attack();

            _cooldownTimer -= Time.deltaTime;
        }
        
        private void CalculateMovement() {
            if ( _movePoints <= 0 || _navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance ) {
                _targetPositionOffset = new Vector3(Random.Range(-4,4), 0f, Random.Range(-4,4));
                _navMeshAgent.SetDestination(_enemyIncentives.TargetTransform.position + _targetPositionOffset);

                // if (Random.Range(0, 5) > 3)
                if ( Math.Abs(_dodgePoints % 5 ) < 1 )
                    _navMeshAgent.SetDestination(thisTransform
                        .TransformPoint(Vector3.right * Random.Range(-5, 5)));

                _movePoints = 50;
                _dodgePoints++;
            }
            _movePoints--;
        }
        
        private void Attack() {
            if( Physics.Linecast(thisTransform.position, _enemyIncentives.TargetTransform.position, viewMask) )
                return;
            
            _navMeshAgent.transform.LookAt(_enemyIncentives.TargetTransform.position);

            _navMeshAgent.velocity = Vector3.zero;
            _attackAnim = true;

            StartCoroutine(TurnOffAnimAfter(0.5f));
            
            GetComponentInParent<Animator>().Play("Attack");

            _projectile = ObjectPooler.SharedInstance.GetPooledObject(projectileTag);

            if ( _projectile == null ) 
                return;

            projectileTransform.LookAt(_enemyIncentives.TargetTransform);
            
            _projectile.transform.position = projectileTransform.position;
            _projectile.transform.rotation = projectileTransform.rotation;

            StartCoroutine(SpawnProjectileAfter(0.5f));

            _cooldownTimer = Cooldown;
        }

        private IEnumerator TurnOffAnimAfter(float time) {
            yield return new WaitForSeconds(time);

            _attackAnim = false;
        }
        private IEnumerator SpawnProjectileAfter(float time) {
            yield return new WaitForSeconds(time);

            _projectile.SetActive(true);
        }

        public override void Exit() { }
        
        Color debugC = new Color(1,0.5f,0.5f);
        private void OnDrawGizmos() {
            if ( _navMeshAgent == null )
                return;
            
            Handles.color = debugC;
            Handles.DrawAAPolyLine(_navMeshAgent.path.corners);
            
            Gizmos.DrawWireCube(_navMeshAgent.pathEndPosition, Vector3.one);
        }
    }
}