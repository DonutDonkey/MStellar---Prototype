using System.Collections.Generic;
using Actor.Enemy;
using Data.Values;
using UnityEngine;

namespace Actor.Player.Weapons {
    public class HitScanWeapon : Weapon {
        [SerializeField] private FloatValue distance;
        [SerializeField] private FloatValue damage;
        
        [SerializeField] private bool usesAmmo;
        
        private GameObject _particleBlood;
        private GameObject _particleImpact;

        public override void Attack() {
            if(usesAmmo && WeaponData.Ammunition <= 0) return;
            
            if(audioSource != null) audioSource.Play(0);
            
            GetComponent<Animator>().Play("Attack");


            var ray = GetRayFromCamera();
            
            if (Physics.Raycast(ray, out var hit, distance.value)) {
                if (hit.transform.gameObject.GetComponent<ActorData>() != null) {
                    hit.transform.gameObject.GetComponent<EnemyData>()
                        .TakeDamage(DamageReductionPerDistance(hit.transform), 
                            GetComponentInParent<ActorData>());
                    
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

            if (usesAmmo)
                WeaponData.Ammunition -= 1;
        }

        private float DamageReductionPerDistance(Transform hitTransform) =>
            (Vector3.Distance(cam.transform.position, hitTransform.position) < 2)
                ? damage * 2
                : damage;

        private void OnDrawGizmosSelected() {
            var ray = GetRayFromCamera();
            Debug.DrawRay(ray.origin, ray.direction * distance.value, Color.yellow);
            Gizmos.DrawWireSphere(transform.position, 3f);
        }
        
        //CapsuleCast if recoil / wider?
        private Ray GetRayFromCamera() => cam.ScreenPointToRay(Input.mousePosition);

        // 4 rays  with distance +-x and +-y for spread?
        private List<Ray> GetRaysFromCamera() {
            List<Ray> result;
            result = new List<Ray>
            {
                cam.ScreenPointToRay(Input.mousePosition + new Vector3(5, 0, 0)),
                cam.ScreenPointToRay(Input.mousePosition + new Vector3(-5, 0, 0)),
                cam.ScreenPointToRay(Input.mousePosition + new Vector3(0, 5, 0)),
                cam.ScreenPointToRay(Input.mousePosition + new Vector3(0, -5, 0))
            };
            return result;
        }
    }
}