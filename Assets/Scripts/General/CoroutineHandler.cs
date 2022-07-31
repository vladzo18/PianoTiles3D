using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General 
{
    public class CoroutineHandler : MonoBehaviour 
    {

        private static CoroutineHandler _instance;
        public static CoroutineHandler Instance => _instance;

        private List<Coroutine> _coroutines;

        private void Awake() 
        {
            if (!_instance) 
            {
                _instance = this;
                _coroutines = new List<Coroutine>();
            }
        }

        public void PlayCoroutine(IEnumerator routine) 
        {
            Coroutine coroutine = StartCoroutine(routine);
            _coroutines.Add(coroutine);
        }

        public void StopCoroutine(Coroutine coroutine) 
        {
            StopCoroutine(coroutine);
            _coroutines.Remove(coroutine);
        }

        public void StopAllCoroutines() 
        {
            foreach (var coroutine in _coroutines)
                StopCoroutine(coroutine);

            _coroutines.Clear();
        }
    }
}