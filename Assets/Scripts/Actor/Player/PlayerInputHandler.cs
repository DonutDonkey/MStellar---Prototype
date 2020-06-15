using Data;
using Data.Values;
using UnityEngine;

namespace Actor.Player {
    public class PlayerInputHandler : MonoBehaviour {
        [SerializeField] private FloatValue mouseSensitivity;

        private CharacterController _characterController;
        
        public FloatValue gravity;
        
        private void Awake() {
            Cursor.lockState = CursorLockMode.Locked;
            _characterController = GetComponent<CharacterController>();
        }

        public Vector3 GetMotion(float horizontal, float vertical) => transform.right   * horizontal + 
                                                                      transform.forward * vertical;

        public float GetMouseVerticalMovement() => Input.GetAxis(MsConstants.MOUSE_AXIS_NAME_VERTICAL) 
                                                   * mouseSensitivity * Time.deltaTime;
        
        public float GetMouseHorizontalMovement() => Input.GetAxis(MsConstants.MOUSE_AXIS_NAME_HORIZONTAL) 
                                                     * mouseSensitivity * Time.deltaTime;

        public float GetVelocity(Vector3 velocity) => (_characterController.isGrounded) 
            ? 0f 
            : velocity.y + gravity * Time.deltaTime;

        public float GetJumpVelocity(Vector3 velocity, float jumpForce) => 
            (Input.GetButton(MsConstants.JUMP_INPUT_NAME) && _characterController.isGrounded)
                ? Mathf.Sqrt(jumpForce * -2f * gravity)
                : velocity.y;
        
        public float GetVerticalMovement() => Input.GetAxis(MsConstants.AXIS_NAME_VERTICAL);

        public float GetHorizontalMovement() => Input.GetAxis(MsConstants.AXIS_NAME_HORIZONTAL);

        public float GetGlobalMovementInput() => Mathf.Abs(GetVerticalMovement()) + 
                                                 Mathf.Abs(GetHorizontalMovement());
        
        public bool GetAttackButton() => Input.GetButton(MsConstants.ATTACK_INPUT_NAME);
        
        public bool IsJumping() => Input.GetButton(MsConstants.JUMP_INPUT_NAME);
        
        public bool IsGrounded() => _characterController.isGrounded;
    }
}