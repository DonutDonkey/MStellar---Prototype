using Data.Values;
using UnityEngine;

namespace Data.GameObjectsData {
    [CreateAssetMenu(fileName = "New Weapon Data", menuName = "Object Data/Weapon", order = 0)]
    public class WeaponData : ScriptableObject {
        [Header("Values")]
        
        [SerializeField] private FloatValue ammunition;
        [SerializeField] private FloatValue maxAmmunition;
        [SerializeField] private FloatValue cooldown;
        
        [SerializeField] private BooleanValue hasProjectile;

        [Header("References")] 
        
        [SerializeField] private GameObject weaponObject;
        [SerializeField] private GameObject projectileObject;
        
        [SerializeField] private AudioClip [] audioClips;

        public FloatValue Ammunition => ammunition;

        public FloatValue MaxAmmunition => maxAmmunition;

        public FloatValue Cooldown => cooldown;

        public BooleanValue HasProjectile => hasProjectile;

        public GameObject WeaponObject => weaponObject;

        public GameObject ProjectileObject => projectileObject;

        public AudioClip[] AudioClips => audioClips;
    }
}