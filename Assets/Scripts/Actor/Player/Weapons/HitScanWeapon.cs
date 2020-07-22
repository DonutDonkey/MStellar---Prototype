using Data.Values;
using UnityEngine;

namespace Actor.Player.Weapons {
    public class HitScanWeapon : Weapon {
        [SerializeField] private FloatValue distance;

        [SerializeField] private UnityEngine.Camera cam;
        

        public override void Attack() {
            GetComponent<Animator>().Play("Attack");

            var ray = GetRayFromCamera();

            if (Physics.Raycast(ray, out var hit, distance.value)) {
                Debug.Log(this.GetType() + " ATTACK() - HIT " + hit.transform.name);
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