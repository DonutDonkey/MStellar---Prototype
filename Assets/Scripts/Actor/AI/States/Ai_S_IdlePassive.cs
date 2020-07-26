using Actor.Enemy.AI;
using UnityEngine;

namespace Actor.AI.States {
    public class Ai_S_IdlePassive : State {
        [SerializeField] private EnemyDebug debugInfo;
        public EnemyDebug DebugInfo { get => debugInfo; set => debugInfo = value; }

        private static readonly int Aggro = Animator.StringToHash("Aggro");

        public override void Enter() {
#if UNITY_EDITOR
            DebugInfo.DebugText.text = GetType().ToString();
            DebugInfo.DebugText.color = Color.green;
            DebugInfo.HearingColor = Color.green;
#endif            
            var anim = GetComponentInParent<Animator>();
            anim.SetBool(Aggro, false);
        }

        public override void Tick() {
        }

        public override void Exit() { }
    }
}