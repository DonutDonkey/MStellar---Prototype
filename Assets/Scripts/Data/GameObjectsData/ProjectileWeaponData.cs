using UnityEngine;

namespace Data.GameObjectsData {
    class ProjectileWeaponData : WeaponData {
        [SerializeField] private GameObject projectile;

        public GameObject Projectile => projectile;
    }
}