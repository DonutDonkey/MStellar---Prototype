﻿using System;
using System.Collections.Generic;
using Data.GameObjectsData;
using Data.Values;
using UnityEngine;

[Serializable]
public class S_GameManager_ScriptableObjectsInitializer : MonoBehaviour {
    [Header("References")]
    
    [SerializeField] private FloatValue playerHealth;
    [SerializeField] private FloatValue playerArmor;

    [SerializeField] private List<WeaponData> playerWeaponsList;

    [Header("Values")] 
    
    [SerializeField] private float setPlayerHealthTo;
    [SerializeField] private float setPlayerArmorTo;
    
    [SerializeField] private bool sceneShouldLoadPlayerData;

    public static float PlayerCurrentHealth;
    public static float PlayerCurrentArmor;
    
    public static bool ShouldInitializeFreshData;

    private void Awake() {
        ShouldInitializeFreshData = sceneShouldLoadPlayerData;

        if (!ShouldInitializeFreshData) return;
        
        PlayerCurrentHealth = setPlayerHealthTo;
        PlayerCurrentArmor = setPlayerArmorTo;
    }
    

    private void OnEnable() {
        playerHealth.value = PlayerCurrentHealth;

        playerArmor.value = PlayerCurrentArmor;
    }
}