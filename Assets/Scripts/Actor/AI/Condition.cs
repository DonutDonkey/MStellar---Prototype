using UnityEngine;

namespace Actor.AI {
    /**
     * Abstract condition class used to extend and create Scriptable Condition Object
     * Each new ScriptableObject that extends this class should implement the condition logic,
     * with will be used in transitions between states
     */
    public abstract class Condition : ScriptableObject {
        public abstract bool IsTrue();
    }
}
