namespace GameplayAudioSystem.MelodyInterpreter 
{
    public class ChordInterpreter 
    {
        private readonly NoteInterpreter _noteInterpreter;
        private readonly DurationInterpreter _durationInterpreter;

        private const string OpenChordToken = "(";
        private const string CloseChordToken = ")";
        private const string NotesSeparator = ",";
        
        public ChordInterpreter(NoteInterpreter interpreter, DurationInterpreter durationInterpreter) 
        {
            _noteInterpreter = interpreter;
            _durationInterpreter = durationInterpreter;
        }

        public Chord  InterpretChord(string token) 
        {
            string temp = token.Clone().ToString();
            string duration = temp.Substring(temp.IndexOf(CloseChordToken) + 1);
            
            temp = temp.Replace(duration, string.Empty);
            temp = temp.Replace(OpenChordToken, string.Empty);
            temp = temp.Replace(CloseChordToken, string.Empty);
            
            string[] notesTokens = temp.Split(char.Parse(NotesSeparator));
            
            Chord chord = new Chord();

            for (int i = 0; i < notesTokens.Length; i++) 
            {
                Note note = _noteInterpreter.InterpretNote(notesTokens[i]);
                note.Duration = _durationInterpreter.InterpretDuration(duration);
                chord.AddNote(note);
            }

            return chord;
        }

        public bool isChord(string token) => token.Contains(OpenChordToken);
    }
}