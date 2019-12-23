using System;
using Data.Values;
using UnityEngine;

namespace Actor.Player.Weapons {
    public class WeaponInputMovement : MonoBehaviour {
        [SerializeField] private FloatValue boppingSpeed;
        [SerializeField] private FloatValue boppingAmount;
        
        [SerializeField] private GameObject weaponObject;
        
        private PlayerInputHandler _playerInputHandler;

        private float _timer = 0f;
        
        private void Awake() => _playerInputHandler = GetComponent<PlayerInputHandler>();

        private void FixedUpdate() {
            var localWeaponPosition = weaponObject.transform.localPosition;
            
            if(_playerInputHandler.GetGlobalMovementInput() > 0)
                WeaponTransformMovement(localWeaponPosition);
            else
                WeaponIdleMovement(localWeaponPosition);
        }

        private void WeaponTransformMovement(Vector3 localWeaponPosition) {
            _timer += Time.deltaTime * boppingSpeed;
            weaponObject.transform.localPosition = SetBopLocalPosition(localWeaponPosition);
        }

        private void WeaponIdleMovement(Vector3 localWeaponPosition) {
            _timer = 0f;
            weaponObject.transform.localPosition = SetIdleLocalPosition(localWeaponPosition);
        }

        private Vector3 SetBopLocalPosition(Vector3 localPosition) => new Vector3
        (1 + Mathf.Sin(_timer) * boppingAmount,
            localPosition.y,
            localPosition.z);
        
        private Vector3 SetIdleLocalPosition(Vector3 localPosition) => new Vector3
        (Mathf.Lerp(localPosition.x, 1, Time.deltaTime * boppingSpeed),
            localPosition.y, 
            localPosition.z);
    }
}