using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Actor.Player.Weapons {
    [SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
    public class WeaponCameraFollow : MonoBehaviour {
        [SerializeField] private Transform leader;
        
        [SerializeField] private float smoothSpeed = 0.124f;

        public Vector3 offset;
        
        private void LateUpdate () {
            transform.localPosition = leader.localPosition + offset;
        }
    }
}