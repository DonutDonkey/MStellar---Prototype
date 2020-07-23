using Data.Values;
using UnityEngine;

namespace Actor.Player.Weapons {
    public class HitScanWeapon : Weapon {
        [SerializeField] private FloatValue distance;
        [SerializeField] private FloatValue damage;

        [SerializeField] private UnityEngine.Camera cam;

        private GameObject _particleBlood;
        private GameObject _particleImpact;

        public override void Attack() {
            GetComponent<Animator>().Play("Attack");

            var ray = GetRayFromCamera();

            if (Physics.Raycast(ray, out var hit, distance.value)) {
                if (hit.transform.gameObject.GetComponent<ActorData>() != null) {
                    hit.transform.gameObject.GetComponent<ActorData>()
                        .TakeDamage(DamageReductionPerFistance(hit.transform));
                    hit.transform.gameObject.GetComponent<Animator>().Play("Hurt");

                    _particleBlood = ObjectPooler.SharedInstance.GetPooledObject("Particle Blood");
                    _particleBlood.transform.position = hit.point;
                    _particleBlood.SetActive(true);
                }

                _particleImpact = ObjectPooler.SharedInstance.GetPooledObject("Hitscan Particle");
                _particleImpact.transform.position = hit.point;
                _particleImpact.SetActive(true);
            }
            
            ResetWeaponCooldown();
        }

        private float DamageReductionPerFistance(Transform hitTransform) =>
            (Vector3.Distance(cam.transform.position, hitTransform.position) < 2)
                ? damage * 2
                : damage;

        private void OnDrawGizmosSelected() {
            var ray = GetRayFromCamera();
            Debug.DrawRay(ray.origin, ray.direction * distance.value, Color.yellow);
            Gizmos.DrawWireSphere(transform.position, 3f);
        }
        
        private Ray GetRayFromCamera() => cam.ScreenPointToRay(Input.mousePosition);
    }
}