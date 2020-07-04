using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Boolean Event", menuName = "Function/Boolean")]
public class EventBool : ScriptableObject {
    [SerializeField] private UnityEvent function;
}
