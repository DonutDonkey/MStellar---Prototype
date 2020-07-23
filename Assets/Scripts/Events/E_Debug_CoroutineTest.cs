using System.Collections;
using UnityEngine;

namespace Events {
    /// <summary>
    /// Class for prototyping and testing working of coroutines
    /// </summary>
    public class E_Debug_CoroutineTest : MonoBehaviour {

        private bool _coroutineWorking;
        private void Update() {
            StartCoroutine(CoroutineTest());
        }

        private IEnumerator CoroutineTest() {
            if (_coroutineWorking)
                yield break;
            
            Debug.Log("Started Coroutine");
            _coroutineWorking = true;
            yield return new WaitForSeconds(10f);
            
            Debug.Log("Ended coroutine after 10 seconds");
            _coroutineWorking = false;
        }
    }
}