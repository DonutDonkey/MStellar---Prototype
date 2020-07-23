using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Actor.Player.Weapons {
    public class WeaponController : MonoBehaviour {
        [SerializeField] private List<GameObject> weapons;

        private PlayerInputHandler _playerInputHandler;
        
        private readonly Dictionary<int, KeyCode> _weaponsList = new Dictionary<int, KeyCode>();

        private Weapon _currentActiveWeapon = null;

        private bool _canSwitchWeapons = true;
        
        private void Awake() => _playerInputHandler = GetComponentInParent<PlayerInputHandler>();

        private void Start() => InitializeWeapons();
        
        private void InitializeWeapons() {
            InitializeWeaponListAssigements();

            ChangeActiveWeapon(0);
            
            _currentActiveWeapon = weapons[0].GetComponent<Weapon>(); // should probably change into game object we
                                                                      // will see
        }

        private void InitializeWeaponListAssigements() {
            _weaponsList.Add(1, KeyCode.Alpha1);
            _weaponsList.Add(2, KeyCode.Alpha2);
        }

        private void Update() {
            if (_canSwitchWeapons) {
                UpdateActiveWeapon();
            }

            if(_playerInputHandler.GetAttackButton() && _currentActiveWeapon.Cooldown <= 0f)
                Attack();

            _currentActiveWeapon.Cooldown -= (_currentActiveWeapon.Cooldown > 0) ? Time.deltaTime : 0;
        }
        
        private void UpdateActiveWeapon() {
            if (_playerInputHandler.GetWeaponNumber(_weaponsList[1]) && IsInInventory()) {
                ChangeActiveWeapon(0);
                StartCoroutine(WeaponSwitchCooldown());
            }

            if (_playerInputHandler.GetWeaponNumber(_weaponsList[2]) && IsInInventory()) {
                ChangeActiveWeapon(1);
                StartCoroutine(WeaponSwitchCooldown());
            }
        }
        
        private IEnumerator WeaponSwitchCooldown() {
            _canSwitchWeapons = false;
            yield return new WaitForSeconds(0.4f);
            _canSwitchWeapons = true;

        }

        //TODO: Inventory logic
        private bool IsInInventory() => true;

        private void ChangeActiveWeapon(int number) {
            foreach (var variable in weapons
                .Where(variable => 
                    variable.name != _currentActiveWeapon?.GetWeaponName() 
                    || weapons[number].name != variable.name)) {
                variable.SetActive(false);
            }
            weapons[number].SetActive(true);
            _currentActiveWeapon = weapons[number].GetComponent<Weapon>();
        }

        private void Attack() => _currentActiveWeapon.Attack();
    }
}
