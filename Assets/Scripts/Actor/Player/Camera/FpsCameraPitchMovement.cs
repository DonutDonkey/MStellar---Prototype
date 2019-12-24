using Data.Values;
using UnityEngine;

namespace Actor.Player.Camera {
    public class FpsCameraPitchMovement : MonoBehaviour {
        [SerializeField] private FloatValue boppingSpeed;
        [SerializeField] private FloatValue boppingAmount;

        [SerializeField] private Transform camTransform;
        
        private PlayerInputHandler _playerInputHandler;

        private float _timer = 0f;
        
        private void Awake() => _playerInputHandler = GetComponentInParent<PlayerInputHandler>();

        private void FixedUpdate() {
            var localPosition = camTransform.localPosition;
            
            if (_playerInputHandler.GetGlobalMovementInput() > 0 && !_playerInputHandler.IsJumping())
                CamMovementTransform(localPosition);
            else
                CamIdleMovement(localPosition);
        }

        private void CamMovementTransform(Vector3 localPosition) {
            _timer += Time.deltaTime * boppingSpeed;
            
            camTransform.localPosition =  SetMoveLocalPosition(localPosition);
        }
        
        private void CamIdleMovement(Vector3 localPosition) {
            _timer = 0f;

            camTransform.localPosition = SetIdleLocalPosition(localPosition);
        }

        private Vector3 SetMoveLocalPosition(Vector3 localPosition) => new Vector3(localPosition.x,
            0 + Mathf.Sin(_timer) * boppingAmount,
            localPosition.z);

        
        private Vector3 SetIdleLocalPosition(Vector3 localPosition) => new Vector3(localPosition.x,
            Mathf.Lerp(localPosition.y, 0, Time.deltaTime * boppingSpeed),
            localPosition.z);
    }
}