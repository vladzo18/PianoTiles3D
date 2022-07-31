namespace GameplayAudioSystem 
{
    public class PianoPlayer 
    {
        private readonly Piano _piano;

        private PianoMelody _pianoMelody;

        private int _currentMelodyIndex;
        
        public PianoPlayer(Piano piano) 
        {
            _piano = piano;
        }

        public void SetMelody(PianoMelody pianoMelody) => _pianoMelody = pianoMelody;

        public void PlayOneChunk() 
        {
           NotationEntity notationEntity = _pianoMelody.GetNotationEntityBy(_currentMelodyIndex++);

           if (notationEntity.Note != null) _piano.Play(notationEntity.Note);
           else if (notationEntity.Pause != null) _piano.Play(notationEntity.Pause);
           else _piano.Play(notationEntity.Chord);
        }
    }
}