using System;
using Data.Values;
using UnityEngine;

namespace Actor.Player.Camera {
    public class FpsCameraHeadBop : MonoBehaviour {
        [SerializeField] private FloatValue bobbingSpeed;
        [SerializeField] private FloatValue bobbingAmount;

        private PlayerInputHandler _playerInputHandler;

        private float _timer = 0f;

        private void Awake() => _playerInputHandler = GetComponentInParent<PlayerInputHandler>();

        private void Update() {
            var localPosition = transform.localPosition;
            if (Math.Abs(_playerInputHandler.GetVerticalMovement()) > 0 && !_playerInputHandler.IsJumping())
                Bop(localPosition);
            else
                StopBop(localPosition);
        }

        private void Bop(Vector3 localPosition) {
            _timer += Time.deltaTime * bobbingSpeed;

            localPosition = SetBopLocalPosition(localPosition);

            transform.localPosition = localPosition;
        }

        private void StopBop(Vector3 localPosition) {
            _timer = 0f;
            
            localPosition = SetIdleLocalPosition(localPosition);

            transform.localPosition = localPosition;
        }

        private Vector3 SetBopLocalPosition(Vector3 localPosition) => new Vector3(localPosition.x,
            0 + Mathf.Sin(_timer) * bobbingAmount,
            localPosition.z);

        private Vector3 SetIdleLocalPosition(Vector3 localPosition) => new Vector3(localPosition.x,
            Mathf.Lerp(localPosition.y, 0, Time.deltaTime * bobbingSpeed), 
            localPosition.z);
    }
}