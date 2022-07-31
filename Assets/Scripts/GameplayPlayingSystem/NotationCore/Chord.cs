using System.Collections.Generic;

namespace GameplayAudioSystem 
{
    public class Chord : NotationEntity
    {
        private List<Note> _notes;

        public Chord()
        {
            _notes = new List<Note>();
            this.Chord = this;
        }

        public void AddNote(Note note) => _notes.Add(note);

        public List<Note> GetTokenNotes() => _notes;
    }
}