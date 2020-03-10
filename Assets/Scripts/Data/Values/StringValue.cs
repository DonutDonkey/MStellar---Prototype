using UnityEngine;

namespace Data.Values {
    [CreateAssetMenu(fileName = "New String", menuName = "Values/String", order = 1)]
    public class StringValue : ScriptableObject {      
        public string value;

        public static implicit operator string(StringValue stringValue) => stringValue.value;
    }
}
