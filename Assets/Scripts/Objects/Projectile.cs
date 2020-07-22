using System;
using Actor;
using Data.Values;
using UnityEngine;
using UnityEngine.UIElements;


namespace Objects {
    public class Projectile : MonoBehaviour {
        [SerializeField] private Transform projectilePointTransform;
        
        [SerializeField] private FloatValue damageRadius;
        [SerializeField] private FloatValue damage;
        [SerializeField] private FloatValue speed;

        [SerializeField] private string ignoreObjectCollisionName;
        [SerializeField] private string particleName;

        private Rigidbody _rigidbody;

        private Vector3 _startingPosition;

        public Transform ProjectilePointTransform
        { get => projectilePointTransform; set => projectilePointTransform = value; }

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        private void OnEnable() {
            _rigidbody.velocity = transform.forward * speed;
            _startingPosition = transform.position;
        }

        private void Update() {
            if( Vector3.Distance(transform.position, _startingPosition) > 100f)
                gameObject.SetActive(false);
        }

        private void OnCollisionEnter(Collision other) {
            Debug.Log(other.gameObject.name);
            
            if (other.gameObject.name.Equals(ignoreObjectCollisionName)) 
                return;
            
            SpawnImpactParticles(out var particleObj);
            particleObj.SetActive(true);

            var hit = Physics.OverlapSphere(transform.position, damageRadius);
            
            foreach (var variable in hit) 
                DamageActorsIfHit(variable);
            
            gameObject.SetActive(false);
        }

        private void SpawnImpactParticles(out GameObject particleObj) {
            particleObj = ObjectPooler.SharedInstance.GetPooledObject(particleName);
            particleObj.transform.position = transform.position;
        }

        private void DamageActorsIfHit(Component inCollider) {
            var actor = inCollider.transform.GetComponent<ActorData>();
            //second condition only for debug until i unfuck projectiles
            if(actor == null || inCollider.gameObject.name.Equals(ignoreObjectCollisionName))
                return;
            
            actor.TakeDamage(GetFallowDamage(inCollider.transform));
            
            Debug.Log("Projectile.DamageActorsIfHit Distance : " + GetDistance(inCollider.transform));
        }

        private float GetFallowDamage(Transform other) {
            return (float) Math.Round(damage.value - ((GetDistance(other) / 2) * 50));
        }

        private float GetDistance(Transform other) => 
            (float) Math.Round(Vector3.Distance(transform.position, other.position) );

        private void OnDrawGizmos() {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, damageRadius);
        }
    }
}
