using System;
using Data.GameObjectsData;
using Data.Values;
using UnityEngine;

namespace Actor.Player.Weapons {
    public class Weapon : MonoBehaviour {
        [Header("References")]
        
        [SerializeField] private WeaponData weaponData;

        [SerializeField] private GameObject weaponObject;
        [SerializeField] private GameObject projectile;

        [SerializeField] private FloatValue damage;

        private void Awake() {
            throw new NotImplementedException();
        }

        public void Attack() {
            
        }
    }
}