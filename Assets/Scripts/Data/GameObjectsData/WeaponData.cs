using Data.Values;
using UnityEngine;

namespace Data.GameObjectsData {
    [CreateAssetMenu(fileName = "New Weapon Data", menuName = "Object Data/Weapon", order = 0)]
    public class WeaponData : ScriptableObject {
        [Header("References")] 
        
        [SerializeField] private GameObject weaponObject;

        [Header("Values")]
        
        [SerializeField] private FloatValue maxAmmunition;
        [SerializeField] private FloatValue ammunition;
        [SerializeField] private FloatValue cooldown;
        
        public GameObject WeaponObject  => weaponObject;

        public FloatValue MaxAmmunition => maxAmmunition;

        public FloatValue Ammunition    => ammunition;

        public FloatValue Cooldown      => cooldown;
    }
}