using UnityEngine;

namespace GUI {
    public class Ui_Player_MenuEffects : MonoBehaviour
    {
        private static Animator _guiEffectsAnimator;

        private void Awake() => _guiEffectsAnimator = GetComponent<Animator>();

        public static void PlayGuiDeadAnimation() => _guiEffectsAnimator.Play("Anim_Gui_Dead");
    }
}
