using System;
using Data.Values;
using UnityEngine;
using UnityEngine.UI;

namespace Actor.Enemy.AI {
    public class EnemyDebug : MonoBehaviour {
        [SerializeField] private FloatValue hearingRadius;
        
        [SerializeField] private Text text;
        public Color HearingColor { get; set; } = Color.gray;

        public Text DebugText { get => text; set => text = value; }
        
        private void OnDrawGizmosSelected() {
            Gizmos.color = HearingColor;
            
            //Hearing zone
            Gizmos.DrawWireSphere(transform.parent.position, hearingRadius);
            
        }
    }
}
