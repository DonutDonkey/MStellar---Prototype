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

        [SerializeField] private LayerMask viewMask;
        
        [SerializeField] private string projectileTag;
        
        private EnemyIncentives _enemyIncentives;
        
        private NavMeshAgent _navMeshAgent;
        
        private AudioSource _audioSource;

        private GameObject _projectile;
        
        private Vector3 _targetPositionOffset;

        private float _movePoints;
        private float _dodgePoints;
        private float _cooldownTimer;
        
        private bool _attackAnim;
        
        public EnemyDebug DebugInfo { get => debugInfo; set => debugInfo = value; }
        
        private float Cooldown { get; set; }

        private readonly int _aggro = Animator.StringToHash("Aggro");
        
        private void Awake() {
            Cooldown = (GetComponentInParent<ActorData>() is EnemyData enemyData)
                ? enemyData.EnemyCooldown.value
                : 0;

            _audioSource = GetComponent<AudioSource>();
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
            _audioSource.Play();
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
            
            StartCoroutine(DoAfter(0.5f, () => _attackAnim = false));
            
            GetComponentInParent<Animator>().Play("Attack");

            StartCoroutine(DoAfter(0.5f, () => {
                _projectile = ObjectPooler.SharedInstance.GetPooledObject(projectileTag);

                if (_projectile == null)
                    return;

                projectileTransform.LookAt(_enemyIncentives.TargetTransform);

                _projectile.transform.position = projectileTransform.position;
                _projectile.transform.rotation = projectileTransform.rotation;
                _projectile.SetActive(true);
            } ) );
            _cooldownTimer = Cooldown;
        }
        
        private IEnumerator DoAfter(float time, Action thisAction) {
            Debug.Log("Coroutine started : " + thisAction.GetType());
            yield return new WaitForSeconds(time);
            thisAction();
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