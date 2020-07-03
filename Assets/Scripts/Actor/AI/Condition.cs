using System;
using UnityEngine;

namespace Actor.AI {
    /**
     * Abstract condition class used to extend and create Scriptable Condition Object
     * Each extensions needs to crete one single boolean function for that specific condition
     * and then assign that method to the func field.
     */
    public abstract class Condition : ScriptableObject {
        public Func<bool> IsTrue { get; }
    }
}
