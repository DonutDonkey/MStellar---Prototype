using System;
using Data.Values;
using UnityEngine;

[Serializable]
public class S_GameManager_ScriptableObjectsInitializer : MonoBehaviour {
    [Header("References")]
    
    [SerializeField] private FloatValue playerWep01Ammo;
    [SerializeField] private FloatValue playerWep02Ammo;
    [SerializeField] private FloatValue playerHealth;
    [SerializeField] private FloatValue playerArmor;

    [SerializeField] private BooleanValue playerWep01IsInEq;
    [SerializeField] private BooleanValue playerWep02IsInEq;


    [Header("Setting Values")] 
    
    [SerializeField] private float setPlayerWep01AmmoTo;
    [SerializeField] private float setPlayerWep02AmmoTo;
    [SerializeField] private float setPlayerHealthTo;
    [SerializeField] private float setPlayerArmorTo;
    
    [SerializeField] private bool sceneShouldLoadPlayerData;
    [SerializeField] private bool setWep01IsInEqTo;
    [SerializeField] private bool setWep02IsInEqTo;

    public static float PlayerCurrentWep01Ammo;
    public static float PlayerCurrentWep02Ammo;
    public static float PlayerCurrentHealth;
    public static float PlayerCurrentArmor;
    
    public static bool PlayerCurrentWep01Eq;
    public static bool PlayerCurrentWep02Eq;
    
    public static bool ShouldInitializeFreshData;
    public static bool IsLoadingLevelAgain;

    private void Awake() {
        ShouldInitializeFreshData = sceneShouldLoadPlayerData;

        SetScriptableObjectValues();
    }

    private void SetScriptableObjectValues() {
        SetPlayerCurrentWep01Ammo();
        SetPlayerCurrentWep02Ammo();
        SetPlayerCurrentHealth();
        SetPlayerCurrentArmor();
        SetPlayerEquipment();
    }

    private void SetPlayerCurrentWep01Ammo() => PlayerCurrentWep01Ammo = (ShouldInitializeFreshData)
        ? setPlayerWep01AmmoTo
        : playerWep01Ammo.value;
    
    private void SetPlayerCurrentWep02Ammo() => PlayerCurrentWep02Ammo = (ShouldInitializeFreshData)
        ? setPlayerWep02AmmoTo
        : playerWep02Ammo.value;
    
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
        if (IsLoadingLevelAgain) return;
        
        playerWep01Ammo.value = PlayerCurrentWep01Ammo;
        playerWep02Ammo.value = PlayerCurrentWep02Ammo;
        playerHealth.value = PlayerCurrentHealth;
        playerArmor.value = PlayerCurrentArmor;
        playerWep01IsInEq.value = PlayerCurrentWep01Eq;
        playerWep02IsInEq.value = PlayerCurrentWep02Eq;
    }
    
}
