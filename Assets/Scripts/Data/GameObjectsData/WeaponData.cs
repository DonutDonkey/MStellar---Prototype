using Data.Values;
using UnityEngine;

namespace Data.GameObjectsData {
    [CreateAssetMenu(fileName = "New Weapon Data", menuName = "Object Data/Weapon", order = 0)]
    public class WeaponData : ScriptableObject {
        [Header("Values")]
        
        [SerializeField] private FloatValue ammunition;
        [SerializeField] private FloatValue maxAmmunition;
        [SerializeField] private FloatValue cooldown;
        

        [Header("References")] 
        
        [SerializeField] private GameObject weaponObject;
        

        public FloatValue Ammunition => ammunition;

        public FloatValue MaxAmmunition => maxAmmunition;

        public FloatValue Cooldown => cooldown;

        public GameObject WeaponObject => weaponObject;
        
    }
}