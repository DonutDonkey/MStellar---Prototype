using UnityEngine;

namespace Data.Values {
    [CreateAssetMenu(fileName = "New Float", menuName = "Values/Float", order = 0)]
    public class FloatValue : ScriptableObject {
        public float value;

        public static implicit operator float(FloatValue floatValue) => floatValue.value;
    }
}