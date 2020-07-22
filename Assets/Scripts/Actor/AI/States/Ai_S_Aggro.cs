using System.Collections;
using Actor.Enemy;
using Actor.Enemy.AI;
using Objects;
using UnityEngine;
using UnityEngine.AI;

namespace Actor.AI.States {
    public class Ai_S_Aggro : State {
        [SerializeField] private EnemyDebug debugInfo;

        [SerializeField] private Transform projectileTransform;

        [SerializeField] private string projectileTag;
        
        private NavMeshAgent _navMeshAgent;
        
        private GameObject _projectile;

        private float _cooldownTimer = 0f;
        private float Cooldown { get; set; }
        
        private readonly int _aggro = Animator.StringToHash("Aggro");

        private bool attackAnim;

        private void Awake() => Cooldown = (GetComponentInParent<ActorData>() is EnemyData enemyData)
            ? enemyData.EnemyCooldown.value
            : 0;

        public EnemyDebug DebugInfo { get => debugInfo; set => debugInfo = value; }

        public override void Enter() {
            DebugInfo.DebugText.text = GetType().ToString();
            DebugInfo.DebugText.color = Color.red;
            DebugInfo.HearingColor = Color.red;

            _navMeshAgent = GetComponentInParent<NavMeshAgent>();
            var anim = GetComponentInParent<Animator>();
            anim.SetBool(_aggro, true);
        }

        public override void Tick() {
            _navMeshAgent.SetDestination(GameObject.Find("Player").transform.position);
            
            if(_cooldownTimer <= 0)
                Attack();

            _cooldownTimer -= Time.deltaTime;
        }

        private void Attack() {
            GetComponentInParent<Animator>().Play("Attack");

            GetComponentInParent<Transform>().LookAt(GameObject.Find("Player").transform.position);

            _projectile = ObjectPooler.SharedInstance.GetPooledObject(projectileTag);

            if ( _projectile == null ) 
                return;

            projectileTransform.LookAt(GameObject.Find("Player").transform.position);
            
            _projectile.transform.position = projectileTransform.position;
            _projectile.transform.rotation = projectileTransform.rotation;

            _projectile.SetActive(true);

            _cooldownTimer = Cooldown;
        }

        public override void Exit() { }
    }
}