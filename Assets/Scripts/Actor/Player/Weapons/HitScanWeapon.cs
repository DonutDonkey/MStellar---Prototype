using Data.Values;
using UnityEngine;

namespace Actor.Player.Weapons {
    public class HitScanWeapon : Weapon {
        [SerializeField] private FloatValue distance;
        public override void Attack() {
            GetComponent<Animator>().Play("Attack");
        }
    }
}