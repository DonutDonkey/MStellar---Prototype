using Actor.AI;
using Data.Values;
using UnityEngine;

namespace Actor.Enemy.AI {
    public class CndToIdle : Condition {
        [SerializeField] private Transform player;
        [SerializeField] private Transform actor;
        
        [SerializeField] private FloatValue range;

        public override bool IsTrue() => Vector3.Distance(player.position, actor.position) < range;
        
    }
}
