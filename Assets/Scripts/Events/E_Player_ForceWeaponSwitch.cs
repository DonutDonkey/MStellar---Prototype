using Actor.Player.Weapons;
using UnityEngine;

namespace Events {
    public class E_Player_ForceWeaponSwitch : MonoBehaviour {
        [SerializeField] private WeaponController weaponController;
        [SerializeField] private int weaponNumber;

        private void OnTriggerEnter(Collider other) {
            if(other.gameObject.name.Equals("Player"))
                weaponController.CallChangeActiveWeapon(weaponNumber);
        }
    }
}