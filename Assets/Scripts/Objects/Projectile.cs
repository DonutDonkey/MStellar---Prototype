using System;
using Actor;
using Data.Values;
using UnityEngine;


namespace Objects {
    public class Projectile : MonoBehaviour {
        [SerializeField] private Transform projectilePointTransform;
        
        [SerializeField] private FloatValue damageRadius;
        [SerializeField] private FloatValue damage;
        [SerializeField] private FloatValue speed;

        [SerializeField] private string particleName;

        private Rigidbody _rigidbody;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        private void OnEnable() => _rigidbody.velocity = projectilePointTransform.forward * speed;

        private void OnCollisionEnter(Collision other) {
            Debug.Log(other.gameObject.name);
            
            if (other.gameObject.name.Equals("Player")) 
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
            
            if(actor == null)
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
