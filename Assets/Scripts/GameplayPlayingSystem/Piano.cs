using GameplayAudioSystem.Storage;
using General;
using UnityEngine;

namespace GameplayAudioSystem 
{
    public class Piano 
    {
        private readonly NoteSoundsStorage _noteSoundsStorage;
        private readonly AudioSourcePool _audioPool;
        
        public float BaseVolume { get; set; } = 0.25f;
       
        public Piano(NoteSoundsStorage noteSoundsStorage, AudioSourcePool audioPool) 
        {
            _noteSoundsStorage = noteSoundsStorage;
            _audioPool = audioPool;
        }
        
        public void Play(Chord chord) 
        {
            foreach (var note in chord.GetTokenNotes())
                Play(note);
            
        }
        
        public void Play(Note note) 
        {
            AudioSource source = _audioPool.GetFreeAudioSource();
            source.clip = _noteSoundsStorage.GetNoteSound(note.OctaveType, note.NoteType);
            source.volume = BaseVolume;
            source.PlayAndFadeOuyAt(note.Duration * source.clip.length);
        }
        
        public void Play(Pause pause) 
        {
            AudioSource source = _audioPool.GetFreeAudioSource();
            source.clip = _noteSoundsStorage.Pause;
            source.volume = BaseVolume;
            source.PlayAndFadeOuyAt(pause.Duration * source.clip.length);
        }
    }
}