using Data.GameObjectsData;
using Data.Values;
using MortemStellar;
using UnityEngine;
using System;
using Data;

namespace Actor.Player.Weapons {
    public class Weapon : MonoBehaviour {
        [Header("References")]
        
        [SerializeField] private GameObject weaponObject;

        [SerializeField] private WeaponData weaponData;

        [SerializeField] private FloatValue damage;

        [SerializeField] private Transform projectileTransform;

        private GameObject _projectile;
        
        public void Attack() {
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