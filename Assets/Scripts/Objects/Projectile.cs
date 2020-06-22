using System;
using Data;
using Data.Values;
using MortemStellar;
using UnityEngine;
using UnityEngine.Serialization;

namespace Objects {
    public class Projectile : MonoBehaviour {
        [SerializeField] private Transform projectilePointTransform;
        
        [SerializeField] private FloatValue damageRadius;
        [SerializeField] private FloatValue speed;

        [SerializeField] private string particleName;

        private Rigidbody _rigidbody;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        private void OnEnable() => _rigidbody.velocity = projectilePointTransform.forward * speed;

        private void OnCollisionEnter(Collision other) {
            Debug.Log(other.gameObject.name);
            
            if (other.gameObject.name.Equals("Player")) 
                return;
            
            var particleObj = ObjectPooler.SharedInstance.GetPooledObject(particleName);
            particleObj.transform.position = transform.position;
            particleObj.SetActive(true);
            
            gameObject.SetActive(false);
        }
    }
}
