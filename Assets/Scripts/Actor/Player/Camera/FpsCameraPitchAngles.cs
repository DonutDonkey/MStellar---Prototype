using Data;
using UnityEngine;

namespace Actor.Player.Camera {
    public class FpsCameraPitchAngles : MonoBehaviour {
        [Header("References")] 
        
        [SerializeField] private Transform playerCamTransform;
        
        [SerializeField] private float maxAngle = 5f;
        [SerializeField] private float rate = 10f;
        
        private void FixedUpdate() => CameraShift(Input.GetAxis(MsConstants.AXIS_NAME_HORIZONTAL));

        private void CameraShift(float axis) {
            var localRotation = SetLocalRotation(axis);
            playerCamTransform.localRotation = localRotation;
        }
        
        private Quaternion SetLocalRotation(float axis) {
            var localRotation = playerCamTransform.localRotation;

            localRotation = Quaternion
                .Lerp(localRotation, Quaternion.Euler
                        (localRotation.x, localRotation.y, axis * maxAngle), Time.deltaTime * rate);

            return localRotation;
        }
    }
}
