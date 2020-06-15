using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MortemStellar {
    public class ObjectPooler : MonoBehaviour {
        [SerializeField] private int amountToPool;

        private List<GameObject> _pooledObjects;

        public static ObjectPooler SharedInstance;

        public GameObject objectToPool;

        private void Awake() => SharedInstance = this;

        private void Start() {
            _pooledObjects = new List<GameObject>();

            for (var i = 0; i < amountToPool; i++) {
                GameObject obj = Instantiate(objectToPool);
                obj.SetActive(false);
                _pooledObjects.Add(obj);
            }
        }

        public GameObject GetPooledObject() => 
            _pooledObjects.FirstOrDefault(t => !t.activeInHierarchy);
    }
}