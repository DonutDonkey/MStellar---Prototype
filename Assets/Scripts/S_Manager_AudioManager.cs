using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioClipsList {
    public AudioClip clip;
    public string clipName;
}
public class S_Manager_AudioManager : MonoBehaviour {
    [SerializeField] private List<AudioClipsList> clipList;
    
    private static Dictionary<string, AudioClip> _clipsController;

    private static AudioSource _audioSource;
    
    public static S_Manager_AudioManager Instance { get; private set; }

    private void Awake() {
        if (Instance == null) Instance = this;
        
        S_Manager_AudioManager._clipsController = _clipsController ?? new Dictionary<string, AudioClip>();

        if (_clipsController.Count == 0) {
            foreach (var audioClipsList in clipList)
                _clipsController.Add(audioClipsList.clipName, audioClipsList.clip);
        }

        _audioSource = GetComponent<AudioSource>();
    }

    public static void PlayClip(string clipName) {
        _audioSource.clip = _clipsController[clipName];
        _audioSource.Play();
    }
}
