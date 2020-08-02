using System;
using System.Collections;
using Actor;
using Actor.Player;
using Events;
using GUI;
using UnityEngine;
using UnityEngine.SceneManagement;

internal enum LevelState {
    Playing,
    Finished,
    Dead
}
    
public class S_GameManager_SceneManager : MonoBehaviour {
    [SerializeField] private E_World_LevelTransition levelFinish;
    
    [SerializeField] private PlayerInputHandler inputHandler;

    [SerializeField] private GameObject deadCanvas;
    
    [SerializeField] private ActorData playerData;

    [SerializeField] private int currentLevelId;
    [SerializeField] private int nextLevelId;
    
    private LevelState _currentLevelState;
    
    private IEnumerator _levelStateAction;

    private bool _levelStateActionInProgress;
    
    private void Awake() => _currentLevelState = LevelState.Playing;

    private void Start() => _levelStateActionInProgress = false;

    private void FixedUpdate() {
        _currentLevelState = (playerData.IsDead()) 
            ? LevelState.Dead 
            : LevelState.Playing;
        
        switch (_currentLevelState) {
            case LevelState.Playing:
                break;
            case LevelState.Finished:
                _levelStateAction = FinishLevelStateAction();
                break;
            case LevelState.Dead:
                _levelStateAction = DeadLevelStateAction();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (_levelStateAction != null && !_levelStateActionInProgress)
            StartCoroutine(_levelStateAction);
    }

    private IEnumerator FinishLevelStateAction() {
        _levelStateActionInProgress = true;
        yield return new WaitForSeconds(2f);
        
        //call for some different shit here
    }
    
    private IEnumerator DeadLevelStateAction() {
        _levelStateActionInProgress = true;
        Ui_Player_MenuEffects.PlayGuiDeadAnimation();
        
        yield return new WaitForSeconds(2f);
        
        //Quick and dirty
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        deadCanvas.gameObject.SetActive(true);
    }

    public void RetryOnClick() {
        S_GameManager_ScriptableObjectsInitializer.IsLoadingLevelAgain = true;
        SceneManager.LoadSceneAsync(currentLevelId, LoadSceneMode.Single);
    }

    public void QuitOnClick() => Application.Quit();

    public void LoadScene() => SceneManager.LoadSceneAsync(nextLevelId, LoadSceneMode.Single);
}
