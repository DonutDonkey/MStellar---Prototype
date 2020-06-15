using Data.Values;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data.GameObjectsData {
    [CreateAssetMenu(fileName = "New Weapon Data", menuName = "Object Data/Weapon", order = 0)]
    public class WeaponData : ScriptableObject {
        [Header("Values")]
        
        [SerializeField] private FloatValue maxAmmunition;
        [SerializeField] private FloatValue ammunition;
        [SerializeField] private FloatValue cooldown;

        public FloatValue MaxAmmunition => maxAmmunition;

        public FloatValue Ammunition    => ammunition;

        public FloatValue Cooldown      => cooldown;
    }
}