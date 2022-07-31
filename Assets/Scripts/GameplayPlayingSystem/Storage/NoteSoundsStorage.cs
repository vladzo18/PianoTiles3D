using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace GameplayAudioSystem.Storage 
{
    [CreateAssetMenu(fileName = "NoteSoundsStorage_[Instrument]", menuName = "Storages/NoteSoundsStorage", order = 0)]
    public class NoteSoundsStorage : ScriptableObject 
    {
        [SerializeField] private List<OctaveDescriptor> _descriptors;
        [SerializeField] private AudioClip _pause;

        public AudioClip Pause => _pause;

        public AudioClip GetNoteSound(OctaveType octaveType, NoteType noteType) 
        {
           var octaveDescriptor = _descriptors.Find(o => o.OctaveType == octaveType);

           if (octaveDescriptor == null) return null;
           
           switch (noteType) {
               case NoteType.None:
                   return null;
               case NoteType.C:
                   return octaveDescriptor.C.Audio;
               case NoteType.CSharp:
                   return octaveDescriptor.CSharp.Audio;
               case NoteType.D:
                   return octaveDescriptor.D.Audio;
               case NoteType.DSharp:
                   return octaveDescriptor.DSharp.Audio;
               case NoteType.E:
                   return octaveDescriptor.E.Audio;
               case NoteType.F:
                   return octaveDescriptor.F.Audio;
               case NoteType.FSharp:
                   return octaveDescriptor.FSharp.Audio;
               case NoteType.G:
                   return octaveDescriptor.G.Audio;
               case NoteType.GSharp:
                   return octaveDescriptor.GSharp.Audio;
               case NoteType.A:
                   return octaveDescriptor.A.Audio;
               case NoteType.ASharp:
                   return octaveDescriptor.ASharp.Audio;
               case NoteType.B:
                   return octaveDescriptor.B.Audio;
           }

           return null;
        }
    }
}