using System;
using Data;
using UnityEngine;

namespace Actor.Player.Camera {
    public class FpsCameraPitchAngles : MonoBehaviour {
        [Header("References")] 
        
        [SerializeField] private Transform playerCamTransform;
        
        [SerializeField] private float maxAngle = 5f;
        [SerializeField] private float rate = 10f;
        [SerializeField] private float maxDistance = 0.32f;

        private PlayerInputHandler _playerInputHandler;

        private void Awake() {
            _playerInputHandler = GetComponent<PlayerInputHandler>();
        }

        private void FixedUpdate() => CameraShift(_playerInputHandler.GetHorizontalMovement(),
                                                  _playerInputHandler.GetVerticalMovement());

        private void CameraShift(float axisH, float axisV) {

            playerCamTransform.localRotation = SetLocalRotation(axisH);
            playerCamTransform.localPosition = SetLocalPosition(axisH,axisV);
        }
        
        private Quaternion SetLocalRotation(float axis) {
            var localRotation = playerCamTransform.localRotation;

            localRotation = Quaternion.Lerp(
                localRotation,
                Quaternion.Euler(localRotation.x, localRotation.y, axis * maxAngle),
                Time.deltaTime * rate);

            return localRotation;
        }

        private Vector3 SetLocalPosition(float axisX, float axisZ) {
            var localPosition = playerCamTransform.localPosition;

            localPosition = new Vector3(
                Mathf.Lerp(localPosition.x,axisX * maxDistance, rate),
                localPosition.y,
                Mathf.Lerp(localPosition.z, axisZ * maxDistance, rate));
            
            return localPosition;
        }
    }
}
