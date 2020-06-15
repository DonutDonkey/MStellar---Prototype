using System;
using Data.GameObjectsData;
using Data.Values;
using MortemStellar;
using UnityEngine;

namespace Actor.Player.Weapons {
    public class Weapon : MonoBehaviour {
        [Header("References")]
        
        [SerializeField] private GameObject weaponObject;

        [SerializeField] private WeaponData weaponData;

        [SerializeField] private FloatValue damage;

        [SerializeField] private Transform projectileTransform;

        private GameObject _projectile;

        private void Awake() {
        }

        public void Attack() {
            _projectile = ObjectPooler.SharedInstance.GetPooledObject();

            if (_projectile.Equals(null)) 
                return;
            
            _projectile.transform.position = projectileTransform.position;
            _projectile.transform.rotation = projectileTransform.rotation;
            _projectile.SetActive(true);
        }
    }
}