using UnityEngine;

namespace Data.Values {
    [CreateAssetMenu(fileName = "new ModelViewOffset", menuName = "Options/ModelViewOffset", order = 3)]
    public class ModelViewOffset : ScriptableObject {
        public Vector3 offsetValue;
        public Vector3 centeredOffsetValue;

        public BooleanValue centerModelView;
    }
}