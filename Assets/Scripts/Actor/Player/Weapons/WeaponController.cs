using System;
using System.Collections.Generic;
using UnityEngine;

namespace Actor.Player.Weapons {
    public class WeaponController : MonoBehaviour {
        [SerializeField] private List<GameObject> weapons;

        private PlayerInputHandler _playerInputHandler;
        
        private Weapon _currentActiveWeapon;
        
        private void Awake() => _playerInputHandler = GetComponentInParent<PlayerInputHandler>();

        private void Start() => InitializeWeapons();
        
        private void InitializeWeapons() {
            foreach (var variable in weapons) {
                variable.SetActive(false);
            }
            weapons[0].SetActive(true);
        }
        private void Update() {
            UpdateActiveWeapon();
            
            if(_playerInputHandler.GetAttackButton())
                Attack();
        }

        private void UpdateActiveWeapon() {
            throw new NotImplementedException();
        }

        private void Attack() => _currentActiveWeapon.Attack();
    }
}
