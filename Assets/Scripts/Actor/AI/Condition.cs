﻿using UnityEngine;

namespace Actor.AI {
    /**
     * Abstract condition class used to extend and create Scriptable Condition Object
     * Each new ScriptableObject that extends this class should implement the condition logic,
     * with will be used in transitions between states
     *
     * Each condition is basically a single IF check for that transition
     */
    public abstract class Condition : ScriptableObject {
        public abstract bool IsTrue();
    }
}
