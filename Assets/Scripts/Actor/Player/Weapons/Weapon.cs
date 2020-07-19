using Data.GameObjectsData;
using Data.Values;
using UnityEngine;

namespace Actor.Player.Weapons {
    public class Weapon : MonoBehaviour {
        [Header("References")]
        
        [SerializeField] private GameObject weaponObject;

        [SerializeField] private WeaponData weaponData;

        [SerializeField] private FloatValue damage;

        [SerializeField] private Transform projectileTransform;

        private GameObject _projectile;

        public virtual void Attack() {
            GetComponent<Animator>().Play("Attack");
            
            _projectile = ObjectPooler.SharedInstance.GetPooledObject(weaponData.ProjectileObjectTag);

            if ( _projectile == null || weaponData.Ammunition <= 0) 
                return;
            
            _projectile.transform.position = projectileTransform.position;
            _projectile.transform.rotation = projectileTransform.rotation;
            _projectile.SetActive(true);

            weaponData.Ammunition -= 1;
        }
    }
}