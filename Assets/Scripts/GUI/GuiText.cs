using System.Globalization;
using Data.Values;
using UnityEngine;
using UnityEngine.UI;

namespace GUI {
    public class GuiText : MonoBehaviour {
        [SerializeField] private FloatValue currentHp;
        [SerializeField] private FloatValue currentArmor;
        [SerializeField] private FloatValue maxHp;
        [SerializeField] private FloatValue maxArmor;

        [SerializeField] private Text currentHpText;
        [SerializeField] private Text currentArmorText;

        private void Start() {
            currentHpText.text = currentHp.value.ToString(CultureInfo.InvariantCulture);
            currentArmorText.text = currentArmor.value.ToString(CultureInfo.InvariantCulture);
        }

        private void LateUpdate() {
            if (currentHpText.text != currentHp.value.ToString(CultureInfo.InvariantCulture))
                currentHpText.text = currentHp.value.ToString(CultureInfo.InvariantCulture);
            
            if (currentArmorText.text != currentArmor.value.ToString(CultureInfo.InvariantCulture))
                currentArmorText.text = currentArmor.value.ToString(CultureInfo.InvariantCulture);
        }
    }
}