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

        private float Speed { get; set; }

        private void Awake() => _playerInputHandler = GetComponent<PlayerInputHandler>();

        private void Update() {
            CheckSpeedIncrease();

            var motion = _playerInputHandler
                .GetMotion(_playerInputHandler.GetHorizontalMovement(),
                             _playerInputHandler.GetVerticalMovement());

            _velocity.y = _playerInputHandler.GetVelocity(_velocity);
            _velocity.y = _playerInputHandler.GetJumpVelocity(_velocity, jumpForce);

            characterController.Move(motion * (_speed * Time.deltaTime));
            characterController.Move(_velocity * Time.deltaTime);
            
            CheckSpeedDecrease();
        }

        private void CheckSpeedIncrease() {
            if(!_playerInputHandler.IsGrounded()) return;
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