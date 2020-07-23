using System;
using System.Collections;
using Actor.Enemy;
using Actor.Enemy.AI;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Actor.AI.States {
    public class Ai_S_Aggro : State {
        [SerializeField] private EnemyDebug debugInfo;

        [SerializeField] private Transform projectileTransform;

        [SerializeField] private string projectileTag;
        
        [SerializeField] private LayerMask viewMask;
        
        public EnemyDebug DebugInfo { get => debugInfo; set => debugInfo = value; }
        
        private NavMeshAgent _navMeshAgent;
        
        private GameObject _projectile;

        private EnemyIncentives _enemyIncentives;
        
        private Vector3 _targetPositionOffset;

        private float _movePoints;
        
        private float _cooldownTimer;
        private float Cooldown { get; set; }
        
        private bool _attackAnim;

        private readonly int _aggro = Animator.StringToHash("Aggro");

        private Transform _thisTransform;
        
        private void Awake() {
            Cooldown = (GetComponentInParent<ActorData>() is EnemyData enemyData)
                ? enemyData.EnemyCooldown.value
                : 0;
            
            _targetPositionOffset = Vector3.zero;
            _enemyIncentives = GetComponentInParent<EnemyIncentives>();
            _navMeshAgent = GetComponentInParent<NavMeshAgent>();
            _thisTransform = GetComponentInParent<Transform>();
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

        //debugging only remove later
        private Vector3 debugPos;
        private Vector3 debugOff;
        private void CalculateMovement() {
            if ( _movePoints <= 0) {
                debugPos = _enemyIncentives.TargetTransform.position;
                debugOff = _targetPositionOffset;
                _navMeshAgent.SetDestination(_enemyIncentives.TargetTransform.position + _targetPositionOffset);
                _movePoints = 30;
            }
            _movePoints--;
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(debugPos + debugOff, 0.5f);
        }

        private void Attack() {
            if( Physics.Linecast(_thisTransform.position, _enemyIncentives.TargetTransform.position, viewMask) )
                return;
            
            _navMeshAgent.transform.LookAt(_enemyIncentives.TargetTransform.position);

            _navMeshAgent.velocity = Vector3.zero;
            _attackAnim = true;
            
            _targetPositionOffset = new Vector3(Random.Range(-4,4), 0f, Random.Range(-4,4));

            StartCoroutine(DoAfter(0.5f));
            
            GetComponentInParent<Animator>().Play("Attack");

            _projectile = ObjectPooler.SharedInstance.GetPooledObject(projectileTag);

            if ( _projectile == null ) 
                return;

            projectileTransform.LookAt(_enemyIncentives.TargetTransform);
            
            _projectile.transform.position = projectileTransform.position;
            _projectile.transform.rotation = projectileTransform.rotation;

            _projectile.SetActive(true);

            _cooldownTimer = Cooldown;
        }

        private IEnumerator DoAfter(float time) {
            yield return new WaitForSeconds(time);

            _attackAnim = false;
        }

        public override void Exit() { }
    }
}