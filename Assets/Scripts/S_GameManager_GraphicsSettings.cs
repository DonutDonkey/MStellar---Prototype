using System;
using System.Collections.Generic;
using System.Linq;
using GUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

[Serializable]
internal class SettingsValues {
    private bool _vsync;
    public  bool Vsync { get => _vsync; set => _vsync = value; }
    
    private bool _fullscreeen;
    public  bool Fullscreeen { get => _fullscreeen; set => _fullscreeen = value; }

    private int _resolutionX;
    public  int ResolutionX { get => _resolutionX; set => _resolutionX = value; }
    
    private int _resolutionY;
    public  int ResolutionY { get => _resolutionY; set => _resolutionY = value; }
}
public class S_GameManager_GraphicsSettings : MonoBehaviour {
    private readonly SettingsValues _settings = new SettingsValues();
    
    //TODO: Make it so it doesn't load always when going to main menu
    private void Start() {
        if (SceneManager.GetActiveScene().buildIndex != 0)
            return;

        LoadGraphicSettings();
    }

    private void LoadGraphicSettings() {
        _settings.Vsync = PlayerPrefs.HasKey("vSync")
                          && PlayerPrefs.GetInt("vSync") != 0;

        _settings.Fullscreeen = PlayerPrefs.HasKey("fullscreen") &&
                                PlayerPrefs.GetInt("fullscreen") != 0;

        _settings.ResolutionX = PlayerPrefs.HasKey("resX")
            ? PlayerPrefs.GetInt("resX")
            : Screen.width;

        _settings.ResolutionY = PlayerPrefs.HasKey("resY")
            ? PlayerPrefs.GetInt("resY")
            : Screen.height;

        QualitySettings.vSyncCount = _settings.Vsync ? 1 : 0;
        Screen.SetResolution(_settings.ResolutionX, _settings.ResolutionY, _settings.Fullscreeen);
    }

    public void SaveGraphicSettings() {
        PlayerPrefs.SetInt("vSync", _settings.Vsync ? 1 : 0);
        PlayerPrefs.SetInt("fullscreen", _settings.Fullscreeen ? 1 : 0);
        PlayerPrefs.SetInt("resX", _settings.ResolutionX);
        PlayerPrefs.SetInt("resY", _settings.ResolutionY);
        
        PlayerPrefs.Save();
        
        LoadGraphicSettings();
    }

    public void SetFullscreenSetting(bool value) => _settings.Fullscreeen = value;
    
    public void SetVsyncSetting(bool value) => _settings.Vsync = value;

    public void SetResolution(int value) {
        _settings.ResolutionX = Ui_Game_GraphicSettings.Resolutions[value].width;
        _settings.ResolutionY = Ui_Game_GraphicSettings.Resolutions[value].height;
    }
}
