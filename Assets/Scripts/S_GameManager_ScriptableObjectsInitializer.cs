using System;
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

    [SerializeField] private BooleanValue playerWep01IsInEq;
    [SerializeField] private BooleanValue playerWep02IsInEq;

    [Header("Setting Values")] 
    
    [SerializeField] private float setPlayerHealthTo;
    [SerializeField] private float setPlayerArmorTo;
    
    [SerializeField] private bool sceneShouldLoadPlayerData;
    [SerializeField] private bool setWep01IsInEqTo;
    [SerializeField] private bool setWep02IsInEqTo;

    public static float PlayerCurrentHealth;
    public static float PlayerCurrentArmor;
    
    public static bool ShouldInitializeFreshData;
    
    public static bool PlayerCurrentWep01Eq;
    public static bool PlayerCurrentWep02Eq;

    private void Awake() {
        ShouldInitializeFreshData = sceneShouldLoadPlayerData;

        SetPlayerCurrentHealth();
        SetPlayerCurrentArmor();
        SetPlayerEquipment();
    }
    
    private void SetPlayerCurrentHealth() => PlayerCurrentHealth = (ShouldInitializeFreshData) 
        ? setPlayerHealthTo 
        : playerHealth.value;

    private void SetPlayerCurrentArmor() => PlayerCurrentArmor = (ShouldInitializeFreshData) 
        ? setPlayerArmorTo 
        : playerArmor.value;

    private void SetPlayerEquipment() {
        PlayerCurrentWep01Eq = (ShouldInitializeFreshData)
            ? setWep01IsInEqTo
            : playerWep01IsInEq.value;

        PlayerCurrentWep02Eq = (ShouldInitializeFreshData)
            ? setWep02IsInEqTo
            : playerWep02IsInEq.value;
    }

    private void OnEnable() {
        playerHealth.value = PlayerCurrentHealth;
        playerArmor.value = PlayerCurrentArmor;
        playerWep01IsInEq.value = PlayerCurrentWep01Eq;
        playerWep02IsInEq.value = PlayerCurrentWep02Eq;
    }
    
}
