using Data.Values;
using UnityEngine;

namespace Actor.Player.Weapons {
    public class HitScanWeapon : Weapon {
        [SerializeField] private FloatValue distance;
        [SerializeField] private FloatValue damage;

        [SerializeField] private UnityEngine.Camera cam;

        private GameObject _particle;

        public override void Attack() {
            GetComponent<Animator>().Play("Attack");

            var ray = GetRayFromCamera();

            if (Physics.Raycast(ray, out var hit, distance.value)) {
                if (hit.transform.gameObject.GetComponent<ActorData>() != null) {
                    hit.transform.gameObject.GetComponent<ActorData>().TakeDamage(damage);
                    hit.transform.gameObject.GetComponent<Animator>().Play("Hurt");

                    _particle = ObjectPooler.SharedInstance.GetPooledObject("Particle Blood");
                    _particle.transform.position = hit.transform.position;
                    _particle.SetActive(true);
                }
            }
            
            ResetWeaponCooldown();
        }
        
        private void OnDrawGizmosSelected() {
            var ray = GetRayFromCamera();
            Debug.DrawRay(ray.origin, ray.direction * distance.value, Color.yellow);
        }
        
        private Ray GetRayFromCamera() => cam.ScreenPointToRay(Input.mousePosition);
    }
}