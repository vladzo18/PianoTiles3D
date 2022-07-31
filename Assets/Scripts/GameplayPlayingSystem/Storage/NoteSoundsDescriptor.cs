using System;
using UnityEngine;

namespace GameplayAudioSystem.Storage 
{
    [Serializable]
    public class NoteSoundsDescriptor 
    {
        [SerializeField] private NoteType _noteType;
        [SerializeField] private AudioClip _audio;

        public NoteType NoteType => _noteType;
        public AudioClip Audio => _audio;
    }
}