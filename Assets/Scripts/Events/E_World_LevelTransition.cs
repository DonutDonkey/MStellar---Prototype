using UnityEngine;
using UnityEngine.SceneManagement;

namespace Events {
    public class E_World_LevelTransition : MonoBehaviour {
        [SerializeField] private string nextLevelName;

        private void OnTriggerEnter(Collider other) {
            if (other.name.Equals("Player"))
                SceneManager.LoadSceneAsync(nextLevelName, LoadSceneMode.Single);
        }

    }
}
