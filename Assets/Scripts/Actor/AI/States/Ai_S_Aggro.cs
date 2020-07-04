using Actor.Enemy.AI;
using UnityEngine;

namespace Actor.AI.States {
    public class Ai_S_Aggro : State {
        [SerializeField] private EnemyDebug debugInfo;

        public EnemyDebug DebugInfo { get => debugInfo; set => debugInfo = value; }

        public override void Enter() {
            DebugInfo.DebugText.text = GetType().ToString();
            DebugInfo.DebugText.color = Color.red;
            DebugInfo.HearingColor = Color.red;
        }

        public override void Tick() {
            // throw new System.NotImplementedException();
        }

        public override void Exit() {
            // throw new System.NotImplementedException();
        }
    }
}