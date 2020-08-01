using System;
using UnityEngine;

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

    public static bool IsStarting = true;
    private void Start() {
        if(!IsStarting) return;

        LoadGraphicSettings();
    }

    private void LoadGraphicSettings() {
        _settings.Vsync = PlayerPrefs.HasKey(_settings.Vsync.ToString())
                          && PlayerPrefs.GetInt(_settings.Vsync.ToString()) != 0;

        _settings.Fullscreeen = PlayerPrefs.HasKey(_settings.Fullscreeen.ToString()) &&
                                PlayerPrefs.GetInt(_settings.Fullscreeen.ToString()) != 0;

        _settings.ResolutionX = PlayerPrefs.HasKey(_settings.ResolutionX.ToString())
            ? PlayerPrefs.GetInt(_settings.ResolutionX.ToString())
            : Screen.width;

        _settings.ResolutionY = PlayerPrefs.HasKey(_settings.ResolutionY.ToString())
            ? PlayerPrefs.GetInt(_settings.ResolutionY.ToString())
            : Screen.height;

        QualitySettings.vSyncCount = _settings.Vsync ? 1 : 0;
        Screen.SetResolution(_settings.ResolutionX, _settings.ResolutionY, _settings.Fullscreeen);
    }

    private void SaveGraphicSettings() {
        PlayerPrefs.SetInt(_settings.Vsync.ToString(), _settings.Vsync ? 1 : 0);
        PlayerPrefs.SetInt(_settings.Fullscreeen.ToString(), _settings.Fullscreeen ? 1 : 0);
        PlayerPrefs.SetInt(_settings.ResolutionX.ToString(), _settings.ResolutionX);
        PlayerPrefs.SetInt(_settings.ResolutionY.ToString(), _settings.ResolutionY);
        
        PlayerPrefs.Save();
    }
}
