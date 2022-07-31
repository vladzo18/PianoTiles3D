using System.Collections;
using UnityEngine;

namespace General 
{
    public static class AudioSourceExtension 
    {
        private static readonly WaitForSecondsRealtime _waitForOneMillisecond = new WaitForSecondsRealtime(0.001f);
        
        private static IEnumerator PlayAndFadeOutStopRoutine(AudioSource source, float time) 
        {
            source.Play();
            yield return new WaitForSeconds(time);
            CoroutineHandler.Instance.PlayCoroutine(FadeOutStopRoutine(source));
        }

        private static IEnumerator FadeOutStopRoutine(AudioSource source) 
        {
            while (source.volume > 0f) 
            {
                source.volume -= 0.01f;
                yield return _waitForOneMillisecond;
            }
                
            source.volume = 0f;
        }
        
        public static void PlayAndFadeOuyAt(this AudioSource source, float time) =>
            CoroutineHandler.Instance.PlayCoroutine(PlayAndFadeOutStopRoutine(source, time));
    }
}