using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem {
    [SerializeField] private GameObject objectToPool;
        
    [SerializeField] private int amountToPool;
        
    public GameObject ObjectToPool => objectToPool;
        
    public int AmountToPool => amountToPool;
}
    
public class ObjectPooler : MonoBehaviour {
    [SerializeField] private List<ObjectPoolItem> itemsToPool;
        
    private List<GameObject> _pooledObjects;

    public static ObjectPooler SharedInstance;

    private void Awake() => SharedInstance = this;

    private void Start() {
        _pooledObjects = new List<GameObject>();

        foreach (var item in itemsToPool) {
            for (var i = 0; i < item.AmountToPool; i++) {
                var obj = Instantiate(item.ObjectToPool);
                obj.SetActive(false);
                _pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string inTag) => 
        _pooledObjects.FirstOrDefault(t => !t.activeInHierarchy && t.CompareTag(inTag));
}