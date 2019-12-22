using UnityEngine;

namespace Data.Values {
    [CreateAssetMenu(fileName = "New Float", menuName = "Values/Float", order = 0)]
    public class FloatValue : ScriptableObject {
        public float value;

        public static implicit operator float(FloatValue floatValue) => floatValue.value;

        public static FloatValue operator -(FloatValue floatValue, float value) {
            floatValue.value -= value;
            return floatValue;
        }

        public static FloatValue operator +(FloatValue floatValue, float value) {
            floatValue.value += value;
            return floatValue;
        }        
        
        public static bool operator >(FloatValue floatValue, float value) {
            return floatValue.value > value;
        }

        public static bool operator <(FloatValue floatValue, float value) {
            return floatValue.value < value;
        }
    }
}