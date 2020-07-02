using System;
using Data.Values;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Actor.Enemy.AI {
    public class EnemyDebug : MonoBehaviour {
        [SerializeField] private FloatValue hearingRadius;
        
        [SerializeField] private Text text;
        
        [SerializeField] private StringValue stateText;

        public StringValue StateText { get => stateText; set => stateText = value; }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.yellow;
            
            //Hearing zone
            Gizmos.DrawWireSphere(transform.parent.position, hearingRadius);
            
        }
    }
}
