using UnityEngine;
using UnityEngine.UI;

namespace GUI {
    public class Ui_Player_Completion : MonoBehaviour {
        [SerializeField] private Text enemiesTotal;
        [SerializeField] private Text enemiesCurrent;

        private void Start() {
            enemiesTotal.text = S_GameManager_LocalObserver.Instance.EnemyCountTotal.ToString();
            enemiesCurrent.text = S_GameManager_LocalObserver.Instance.EnemyCountAlive.ToString();
        }

        private void LateUpdate() {
            if (enemiesCurrent.text != S_GameManager_LocalObserver.Instance.EnemyCountAlive.ToString())
                enemiesCurrent.text = S_GameManager_LocalObserver.Instance.EnemyCountAlive.ToString();
        }
    }
}
