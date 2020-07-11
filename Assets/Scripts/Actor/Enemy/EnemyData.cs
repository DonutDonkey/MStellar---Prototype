using Data.Values;
using UnityEngine;

namespace Actor.Enemy
{
    public class EnemyData : ActorData {
        [SerializeField] private FloatValue enemyCooldown;

        public FloatValue EnemyCooldown => enemyCooldown;
    }
}