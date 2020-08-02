using UnityEngine;

namespace Events {
    public class E_Player_FreeMouseLook : MonoBehaviour
    {
        private void Start() {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
