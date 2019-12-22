using System;
using Data.Values;
using UnityEngine;

namespace Actor.Player.Camera {
    public class FpsCameraInputMovement : MonoBehaviour {
        [SerializeField] private FloatValue boppingSpeed;
        [SerializeField] private FloatValue boppingAmount;

        private PlayerInputHandler _playerInputHandler;

        private float _timer = 0f;
        
        private void Awake() => _playerInputHandler = GetComponentInParent<PlayerInputHandler>();

        private void FixedUpdate() {
            var localPosition = transform.localPosition;
            
            if (Math.Abs(_playerInputHandler.GetVerticalMovement()) > 0 && !_playerInputHandler.IsJumping())
                Bop(localPosition);
            else
                CamIdleMovement(localPosition);
        }

        private void Bop(Vector3 localPosition) {
            _timer += Time.deltaTime * boppingSpeed;
            
            transform.localPosition =  SetBopLocalPosition(localPosition);
        }

        private void CamIdleMovement(Vector3 localPosition) {
            _timer = 0f;

            transform.localPosition = SetIdleLocalPosition(localPosition);
        }

        private Vector3 SetBopLocalPosition(Vector3 localPosition) => new Vector3(localPosition.x,
            0 + Mathf.Sin(_timer) * boppingAmount,
            localPosition.z);

        private Vector3 SetIdleLocalPosition(Vector3 localPosition) => new Vector3(localPosition.x,
            Mathf.Lerp(localPosition.y, 0, Time.deltaTime * boppingSpeed), 
            localPosition.z);
    }
}