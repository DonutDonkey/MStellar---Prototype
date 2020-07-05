using Data.Values;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Actor.Enemy.AI {
    public class EnemyDebug : MonoBehaviour {
        [SerializeField] private FloatValue incentivesRadius;
        [SerializeField] private FloatValue hearingRadius;
        [SerializeField] private FloatValue viewRadius;
        [SerializeField] private FloatValue fieldOfView;

        [SerializeField] private Text text;

        [SerializeField] private Transform debugTransform;

        public LayerMask layerMask;
        
        public Color HearingColor { get; set; } = Color.gray;

        public Text DebugText { get => text; set => text = value; }
        
        private void OnDrawGizmosSelected() {
            Gizmos.color = HearingColor;
            
            //Incentives zone
            Gizmos.DrawWireSphere(transform.parent.position, incentivesRadius);
            
            
            //Hearing Zone
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.parent.position, hearingRadius );
            
            //Fov
            DebugDrawFov();
        }
        
        public int steps;
        
        private void DebugDrawFov() {
            var arcSteps = Mathf.RoundToInt(fieldOfView / steps);
            
            var fovColor = HearingColor;
            fovColor.a = 0.24f;
            Handles.color = fovColor;
            
            for (var i = 0; i <= arcSteps; i++) {
                
                var angle = fieldOfView.value - (i * steps);
                Handles.DrawSolidArc(debugTransform.position,
                    debugTransform.up,
                    GetStartAngle(angle * 0.5f), // rotate from forward by step
                    -arcSteps,
                    GetRadiusDistance(angle * 0.5f));                
                
                Handles.DrawSolidArc(debugTransform.position,
                    debugTransform.up,
                    GetStartAngle(-angle * 0.5f), // rotate from forward by step
                    -arcSteps,
                    GetRadiusDistance(-angle * 0.5f));
            }
        }

        private Vector3 GetStartAngle(float startAngle) => 
            Quaternion.AngleAxis(startAngle, Vector3.up) * debugTransform.forward;

        private float GetRadiusDistance(float startAngle) {
            Physics.Raycast(
                debugTransform.position, //Where cast is starting
                GetStartAngle(startAngle), //With direction it is going
                out var hit, //hit point
                layerMask); // obstacles
            
                return ( Vector3.Distance(debugTransform.position, hit.point) > viewRadius) 
                    ? viewRadius
                    : Vector3.Distance(debugTransform.position, hit.point);
        }
        
    }
}
