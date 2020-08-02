using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace GUI {
    public class Ui_Game_GraphicSettings : MonoBehaviour {
        [SerializeField] private Dropdown resolutionDropdown;
        
        public static Resolution[] Resolutions;

        private void Start() {
            Resolutions = Screen.resolutions;
            
            resolutionDropdown.ClearOptions();

            var resolutionOptions = 
                Resolutions.Select(loopRes => loopRes.width + " x " + loopRes.height).ToList();
            
            resolutionDropdown.AddOptions(resolutionOptions);
        }
    }
}
