using System.Collections.Generic;
using System.Linq;
using Actor;
using UnityEngine;

namespace Events {
    public class E_World_EnableOrDisableOnActorsDeath : MonoBehaviour {
        [SerializeField] private List<ActorData> actors;
        
        [SerializeField] private List<GameObject> objects;

        [SerializeField] private ActiveStatusOfObjects action;

        private enum ActiveStatusOfObjects { Disable , Enable }
        
        private bool _status;

        private void Awake() => _status = action == ActiveStatusOfObjects.Enable;

        private void FixedUpdate() {
            if(actors.Count() != 0)
                foreach (var loopActor in actors.Where(loopActor => loopActor.IsDead()))
                    actors.Remove(loopActor);
            else
                foreach (var loopObj in objects) 
                    loopObj.SetActive( _status );
        }
    }
}