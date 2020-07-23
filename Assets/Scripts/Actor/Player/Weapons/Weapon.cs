using Data.GameObjectsData;
using UnityEngine;

namespace Actor.Player.Weapons {
    public class Weapon : MonoBehaviour {
        [Header("References")]
        
        [SerializeField] private GameObject weaponObject;

        [SerializeField] private WeaponData weaponData;
        
        [SerializeField] private Transform projectileTransform;

        private GameObject _projectile;
        
        public float Cooldown { get; set; }

        protected WeaponData WeaponData { get => weaponData; set => weaponData = value; }

        public bool IsCurrentlyEquipped { get; private set; }

        private void Awake() => Cooldown = 0f;

        private void OnEnable() => IsCurrentlyEquipped = true;

        private void OnDisable() => IsCurrentlyEquipped = false;

        public virtual void Attack() {
            GetComponent<Animator>().Play("Attack");
            
            _projectile = ObjectPooler.SharedInstance.GetPooledObject(weaponData.ProjectileObjectTag);

            if ( _projectile == null || weaponData.Ammunition <= 0) 
                return;
            
            _projectile.transform.position = projectileTransform.position;
            _projectile.transform.rotation = projectileTransform.rotation;
            _projectile.SetActive(true);

            weaponData.Ammunition -= 1;

            ResetWeaponCooldown();
        }

        protected float ResetWeaponCooldown() => Cooldown = weaponData.Cooldown.value;

        public string GetWeaponName() => weaponObject.name;
    }
}