using System.Collections.Generic;
using Actor.Enemy;
using UnityEngine;

//ForFuture
public class S_GameManager_SaveManager : MonoBehaviour {
    public static S_GameManager_SaveManager Intstance { get; private set; }
    
    public bool shouldClearData;
    
    public Dictionary<string, bool> enemiesAliveStatusMap;

    private void Awake() => Intstance = (Intstance == null) ? this : Intstance;
    
    private void MapEnemiesAliveData() {
        foreach (var obj in FindObjectsOfType<EnemyData>()) 
            enemiesAliveStatusMap.Add(obj.name, obj.IsDead());
    }

    public void ClearEnemiesAliveStatusMap() => enemiesAliveStatusMap.Clear();

    public void UpdateLifeStatus(string objName, EnemyData obj) => enemiesAliveStatusMap[objName] = obj.IsDead();
}