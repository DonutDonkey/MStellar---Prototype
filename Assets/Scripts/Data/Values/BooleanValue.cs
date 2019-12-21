using UnityEngine;

namespace Data.Values {
    [CreateAssetMenu(fileName = "New Boolean", menuName = "Values/Boolean", order = 2)]
    public class BooleanValue : ScriptableObject {
        public bool value;

        public static implicit operator bool(BooleanValue booleanValue) => booleanValue.value;
    }
}