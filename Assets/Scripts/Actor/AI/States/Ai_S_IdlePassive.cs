using Actor.Enemy.AI;
using UnityEngine;

namespace Actor.AI.States {
    public class Ai_S_IdlePassive : State {
        [SerializeField] private EnemyDebug debugInfo;

        public EnemyDebug DebugInfo { get => debugInfo; set => debugInfo = value; }

        public override void Enter() {
            DebugInfo.DebugText.text = GetType().ToString();
            DebugInfo.DebugText.color = Color.green;
            DebugInfo.HearingColor = Color.green;
            
            var anim = GetComponentInParent<Animator>();
            anim.SetBool("Aggro", false);
        }

        public override void Tick() {
        }

        public override void Exit() {
            // throw new System.NotImplementedException();
        }
    }
}