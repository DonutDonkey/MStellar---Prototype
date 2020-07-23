using System;
using System.Collections.Generic;
using System.Globalization;
using Data.Values;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace GUI {
    [Serializable]
    public class TextContextPairFloatValue {
        [SerializeField] private Text uiText;
        [SerializeField] private FloatValue floatValue;

        public void UpdateTextValue() {
            if (uiText.text.Equals(floatValue.value.ToString(CultureInfo.InvariantCulture)))
                return;
            
            uiText.text = floatValue.value.ToString(CultureInfo.InvariantCulture);
        }
    }
    
    public class Ui_Player_Inventory : MonoBehaviour {
        [SerializeField] private List<TextContextPairFloatValue> textPairsAndValues;

        private void Update() {
            foreach (var loopItem in textPairsAndValues) 
                loopItem.UpdateTextValue();
        }
    }
}