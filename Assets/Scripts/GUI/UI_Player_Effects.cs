using UnityEngine;

namespace GUI {
    public class Ui_Player_Effects : MonoBehaviour {
        private static Animator _guiEffectsAnimator;

        private void Awake() => _guiEffectsAnimator = GetComponent<Animator>();

        public static void PlayGuiHurtAnimation()   => _guiEffectsAnimator.Play("Anim_Gui_Hurt");
        
        public static void PlayGuiArmorAnimation()  => _guiEffectsAnimator.Play("Anim_Gui_PickupArmor");
        
        public static void PlayGuiHealthAnimation() => _guiEffectsAnimator.Play("Anim_Gui_PickupHealth");
    }
}
