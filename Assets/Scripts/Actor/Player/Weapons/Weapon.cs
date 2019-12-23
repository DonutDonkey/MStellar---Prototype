using Data.GameObjectsData;
using UnityEngine;

namespace Actor.Player.Weapons {
    public abstract class Weapon : MonoBehaviour {
        [Header("References")]
        
        [SerializeField] private WeaponsData weaponsData;
    }
}