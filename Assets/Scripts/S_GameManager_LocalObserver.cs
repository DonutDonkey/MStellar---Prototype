using Actor.Enemy;
using UnityEngine;

public class S_GameManager_LocalObserver : MonoBehaviour {
    private int _enemyCountTotal;
    private int _enemyCountAlive = 0;
    
    public static S_GameManager_LocalObserver Instance { get; private set; }

    public int EnemyCountTotal { get => _enemyCountTotal; private set => _enemyCountTotal = value; }
    public int EnemyCountAlive { get => _enemyCountAlive; set => _enemyCountAlive = value; }

    private void Awake() {
        Instance = this;
        
        SetObserverItems();
    }

    public void SetObserverItems() {
        EnemyCountTotal = FindObjectsOfType<EnemyData>().Length;
    }
}
