using UnityEngine;

namespace Actor.Enemy.AI {
    public class StateIdle : IState {
        private EnemyDebug _enemyDebug;
        
        private GameObject _actor;

        public StateIdle(EnemyDebug enemyDebug, GameObject actor) {
            _enemyDebug = enemyDebug;
            _actor = actor;
        }
        
        public void OnEnter() => _enemyDebug.StateText.value = this.GetType().ToString();

        public void Tick() {
            throw new System.NotImplementedException();
        }

        public void OnExit() {
            throw new System.NotImplementedException();
        }
    }
}
