using System;
using GameplayAudioSystem;
using GameplayAudioSystem.Storage;
using UnityEngine;

namespace DefaultNamespace {
    [Serializable]
    public class OctaveDescriptor 
    {
        [SerializeField] private OctaveType _octaveType;
        
        [SerializeField] private NoteSoundsDescriptor _c;
        [SerializeField] private NoteSoundsDescriptor _cSharp;
        [SerializeField] private NoteSoundsDescriptor _d;
        [SerializeField] private NoteSoundsDescriptor _dSharp;
        [SerializeField] private NoteSoundsDescriptor _e;
        [SerializeField] private NoteSoundsDescriptor _f;
        [SerializeField] private NoteSoundsDescriptor _fSharp;
        [SerializeField] private NoteSoundsDescriptor _g;
        [SerializeField] private NoteSoundsDescriptor _gSharp;
        [SerializeField] private NoteSoundsDescriptor _a;
        [SerializeField] private NoteSoundsDescriptor _aSharp;
        [SerializeField] private NoteSoundsDescriptor _b;
        
        public OctaveType OctaveType => _octaveType;

        public NoteSoundsDescriptor C => _c;
        public NoteSoundsDescriptor CSharp => _cSharp;
        public NoteSoundsDescriptor D => _d;
        public NoteSoundsDescriptor DSharp => _dSharp;
        public NoteSoundsDescriptor E => _e;
        public NoteSoundsDescriptor F => _f;
        public NoteSoundsDescriptor FSharp => _fSharp;
        public NoteSoundsDescriptor G => _g;
        public NoteSoundsDescriptor GSharp => _gSharp;
        public NoteSoundsDescriptor A => _a;
        public NoteSoundsDescriptor ASharp => _aSharp;
        public NoteSoundsDescriptor B => _b;
    }
}