using Data.GameObjectsData;
using UnityEngine;

namespace Actor.Player.Weapons {
    public class Weapon : MonoBehaviour {
        [SerializeField] private GameObject weaponObject;

        [SerializeField] private WeaponData weaponData;
        
        [SerializeField] private Transform projectileTransform;

        [SerializeField] protected UnityEngine.Camera cam;
        
        [SerializeField] protected AudioSource audioSource;
        private GameObject _projectile;
        
        public float Cooldown { get; set; }

        public WeaponData WeaponData { get => weaponData; protected set => weaponData = value; }

        public bool IsCurrentlyEquipped { get; private set; }

        private void Awake() => Cooldown = 0f;

        private void Start() {
            if(WeaponData.Ammunition != null) 
                WeaponData.Ammunition.value = (WeaponData.Ammunition.value > WeaponData.MaxAmmunition.value)
                    ? WeaponData.MaxAmmunition.value
                    : WeaponData.Ammunition.value;
        }

        private void OnEnable() => IsCurrentlyEquipped = true;

        private void OnDisable() => IsCurrentlyEquipped = false;

        public virtual void Attack() {
            if(WeaponData.Ammunition <= 0)
                return;
            
            if(audioSource != null) audioSource.Play();
            
            GetComponent<Animator>().Play("Attack");
            
            _projectile = ObjectPooler.SharedInstance.GetPooledObject(weaponData.ProjectileObjectTag);

            if ( _projectile == null || weaponData.Ammunition <= 0) 
                return;
            
            _projectile.transform.position = projectileTransform.position;
            _projectile.transform.rotation = projectileTransform.rotation;
            _projectile.transform.forward  = cam.transform.forward;
            _projectile.SetActive(true);

            weaponData.Ammunition -= 1;

            ResetWeaponCooldown();
        }

        protected float ResetWeaponCooldown() => Cooldown = weaponData.Cooldown.value;

        public string GetWeaponName() => weaponObject.name;
    }
}