using UnityEngine;

namespace Actor.Player.Camera {
    public class FpsCameraMouseLook : MonoBehaviour {
        [Header("References")] 
        
        [Tooltip("Reference for player body object")] 
        [SerializeField] private Transform playerObjectTransform;

        [Tooltip("Reference to camera attachment transform")] 
        [SerializeField] private Transform cameraPointTransform;
        
        private PlayerInputHandler _playerInputHandler;

        private float _xRotation = 0f;
        
        private void Awake() {
            _playerInputHandler = GetComponent<PlayerInputHandler>();
        }

        private void Update() {
            var vertical = _playerInputHandler.GetMouseVerticalMovement();
            var horizontal = _playerInputHandler.GetMouseHorizontalMovement();
            
            _xRotation -= horizontal;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
            cameraPointTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            
            playerObjectTransform.Rotate(Vector3.up * vertical);
        }
    }
}