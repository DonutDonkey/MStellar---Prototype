using UnityEngine;

namespace Data.Values {
    [CreateAssetMenu(fileName = "new ModelViewOffset", menuName = "Options/ModelViewOffset", order = 3)]
    public class ModelViewOffset : ScriptableObject {
        public Vector3 offsetValue;

        public BooleanValue centerModelView;

        public const float DEFAULT_OFFSET_X          = 0.64f;
        public const float DEFAULT_CENTERED_OFFSET_X = 0f;
        public const float DEFAULT_OFFSET_Y          = -0.64f;
        public const float DEFAULT_OFFSET_Z          = 1.28f;
    }
}