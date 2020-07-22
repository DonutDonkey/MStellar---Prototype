using System.Collections.Generic;
using Actor.Enemy;
using UnityEngine;

public class S_GameManager_LocalObserver : MonoBehaviour {
    public static S_GameManager_LocalObserver Instance { get; private set; }
    
    private int _enemyCountTotal;
    private int _enemyCountAlive = 0;
    
    public int EnemyCountTotal { get => _enemyCountTotal; private set => _enemyCountTotal = value; }
    public int EnemyCountAlive { get => _enemyCountAlive; set => _enemyCountAlive = value; }

    private void Awake() {
        Instance = this;
        
        // enemiesAliveStatusMap = new Dictionary<string, bool>();
        
        SetObserverItems();
        // MapEnemiesAliveData();
    }

    private void SetObserverItems() {
        EnemyCountTotal = FindObjectsOfType<EnemyData>().Length;
    }
}
