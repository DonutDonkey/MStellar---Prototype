using Data.Values;
using UnityEngine;

namespace Data.GameObjectsData {
    [CreateAssetMenu(fileName = "New Weapon Data", menuName = "Object Data/Weapon", order = 0)]
    public class WeaponData : ScriptableObject {
        [Header("Values")]
        
        [SerializeField] private FloatValue maxAmmunition;
        [SerializeField] private FloatValue ammunition;
        [SerializeField] private FloatValue cooldown;

        [SerializeField] private BooleanValue isInEq;
        
        [SerializeField] private string projectileObjectTag;

        public FloatValue MaxAmmunition => maxAmmunition;
        public FloatValue Ammunition { get => ammunition; set => ammunition = value; }
        public FloatValue Cooldown => cooldown;

        public BooleanValue IsInEq => isInEq;

        public string ProjectileObjectTag => projectileObjectTag;
    }
}