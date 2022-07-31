using System.Collections.Generic;
using UnityEngine;

namespace GameplayAudioSystem 
{
    public class AudioSourcePool {
        
        private readonly GameObject _audioSourceObject;
        private readonly Transform _parentTransform;

        private readonly List<AudioSource> _audioSources;
        
        private const int StartSourceCount = 20;

        public AudioSourcePool(Transform parentTransformTransform) 
        {
            _audioSources = new List<AudioSource>();
            _parentTransform = parentTransformTransform;
            _audioSourceObject = GenerateAudioSourceGameObject();

            for (int i = 0; i < StartSourceCount; i++)
                AddSource();
        }
        
        public AudioSource GetFreeAudioSource() 
        {
            for (int i = 0; i < _audioSources.Count; i++)
                if (!_audioSources[i].isPlaying) return _audioSources[i];
            
            return AddSource();
        }

        private AudioSource AddSource() 
        {
            GameObject go = GameObject.Instantiate(_audioSourceObject, _parentTransform.transform);
            AudioSource source = go.GetComponent<AudioSource>();
            _audioSources.Add(source);
            return source;
        }
        
        private GameObject GenerateAudioSourceGameObject() 
        {
            GameObject go = new GameObject("AudioSource");
            AudioSource source = go.AddComponent<AudioSource>();
            source.playOnAwake = false;
            return go;
        }
    }
}