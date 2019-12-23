using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Actor.Player.Weapons {
    [SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
    public class ModelView : MonoBehaviour {
        [Header("Values")]
        
        [Tooltip("Reference for main fps camera")]
        [SerializeField] private Transform fpsCamera;

        [Tooltip("List of all weapon objects transforms")]
        [SerializeField] private List<Transform> weapons;
        
        public Vector3 offset;
        
        private void LateUpdate () {
            foreach (var t in weapons) 
                t.localPosition = fpsCamera.localPosition + offset;
        }
    }
}