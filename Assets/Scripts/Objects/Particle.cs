using UnityEngine;

namespace Objects {
    public class Particle : MonoBehaviour {
        private ParticleSystem _particleSystem;
        private void Awake() => _particleSystem = GetComponent<ParticleSystem>();

        private void OnEnable() => _particleSystem.Play();

        private void Update() {
            if (!_particleSystem.isEmitting) 
                gameObject.SetActive(false);
        }
    }
}
