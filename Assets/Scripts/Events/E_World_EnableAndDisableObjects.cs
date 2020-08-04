using System.Collections.Generic;
using UnityEngine;

namespace Events {
    public class E_World_EnableAndDisableObjects : MonoBehaviour {
        [SerializeField] private List<GameObject> objectsToDisable;
        [SerializeField] private List<GameObject> objectsToEnable;

        public string otherColliderName;
        
        private void OnTriggerEnter(Collider other) {
            if (!other.name.Equals(otherColliderName)) return;

            foreach (var loopObj in objectsToDisable)
                loopObj.SetActive(false);

            foreach (var loopObj in objectsToEnable)
                loopObj.SetActive(true);
        }
    }
}
