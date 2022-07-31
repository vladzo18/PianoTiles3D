using System.Collections.Generic;

namespace GameplayAudioSystem.MelodyInterpreter 
{
    public class MelodyInterpreter 
    {
        private readonly NoteInterpreter _noteInterpreter;
        private readonly ChordInterpreter _chordInterpreter;
        private readonly PauseInterpreter _pauseInterpreter;
        private readonly DurationInterpreter _durationInterpreter;

        private readonly IEnumerator<NotationEntity> _melodyEnumerator;
        
        private string _melody;
        
        private const char Separator = ';';
        
        public MelodyInterpreter() 
        {
            _durationInterpreter = new DurationInterpreter();
            _noteInterpreter = new NoteInterpreter(_durationInterpreter);
            _pauseInterpreter = new PauseInterpreter();
            _chordInterpreter = new ChordInterpreter(_noteInterpreter, _durationInterpreter);
            _melodyEnumerator = NoteGroupsEnumerator();
        }

        public void SetMelody(string melody) 
        {
            _melody = melody;
            //_melodyEnumerator?.Reset();
        }

        public NotationEntity GetNext() 
        {
            _melodyEnumerator.MoveNext();
            return _melodyEnumerator.Current;
        }

        public List<NotationEntity> GetMelody() 
        {
            string[] tokens = _melody.Split(Separator);
            List<NotationEntity> melody = new List<NotationEntity>();
            
            for (int i = 0; i < tokens.Length; i++)
               melody.Add(GetNotesGroup(tokens[i]));
            
            return melody;
        }
        
        private IEnumerator<NotationEntity> NoteGroupsEnumerator() 
        {
            string[] tokens = _melody.Split(Separator);

            for (int i = 0; i < tokens.Length; i++)
                yield return GetNotesGroup(tokens[i]);
        }

        private NotationEntity GetNotesGroup(string token) 
        {
            if (_chordInterpreter.isChord(token)) return _chordInterpreter.InterpretChord(token);
            if (_pauseInterpreter.isPause(token)) return _pauseInterpreter.InterpretNote(token);
                
            Chord chord = new Chord();
            chord.AddNote(_noteInterpreter.InterpretNote(token));
            return chord;
        }
    }
}