using System.Collections;
using Data;
using Data.Values;
using UnityEngine;

namespace Actor.Player {
    public class PlayerCharacterController : MonoBehaviour {
        [Header("References")]
        
        [SerializeField] private CharacterController characterController;

        [Header("Values")] 
        
        private float _speed = 10f;
        
        private PlayerInputHandler _playerInputHandler;

        private Vector3 _velocity;

        private bool _isSpeedDecreasing = false;
        private bool _isJumping = false;
        
        public FloatValue jumpForce;
        
        public float speedChangeParameter = 1f;

        public float Speed { get => _speed; set => _speed = value; }

        private void Awake() => _playerInputHandler = GetComponent<PlayerInputHandler>();

        private void Update() {
            CheckSpeedIncrease();

            var motion = _playerInputHandler
                .GetMotion(Input.GetAxis(MsConstants.AXIS_NAME_HORIZONTAL),
                             Input.GetAxis(MsConstants.AXIS_NAME_VERTICAL));

            _velocity.y = _playerInputHandler.GetVelocity(_velocity);
            _velocity.y = _playerInputHandler.GetJumpVelocity(_velocity, jumpForce);

            characterController.Move(motion * (_speed * Time.deltaTime));
            characterController.Move(_velocity * Time.deltaTime);
            
            CheckSpeedDecrease();
        }

        private void CheckSpeedIncrease() {
            if(!characterController.isGrounded) return;
            if (!_isJumping) return;
            
            _isJumping = false;
            _speed += BunnyHopSpeedIncrease();
        }

        private void CheckSpeedDecrease() {
            if (_playerInputHandler.IsJumping()) {
                _isJumping = true;
            }
            else if (!_isSpeedDecreasing) {
                _isSpeedDecreasing = true;
                StartCoroutine(BunnyHopSpeedDecrease());
            }
        }

        private float BunnyHopSpeedIncrease() => (Speed < 15f) ? speedChangeParameter : 0f;

        private IEnumerator BunnyHopSpeedDecrease() {
            while (10f < Speed && _isSpeedDecreasing) {
                Speed -= speedChangeParameter;
                yield return new WaitForSeconds(0.1f);
            }

            _isSpeedDecreasing = false;
        }
    }
}