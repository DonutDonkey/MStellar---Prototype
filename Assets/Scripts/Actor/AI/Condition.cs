using System;
using UnityEngine;

namespace Actor.AI {
    public abstract class Condition : ScriptableObject {
        public Func<bool> IsTrue { get; }
    }
}
