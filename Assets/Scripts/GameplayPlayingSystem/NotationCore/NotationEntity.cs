namespace GameplayAudioSystem 
{
    public abstract class NotationEntity 
    {
        public float Duration;

        public Note Note { get; protected set; } = null;
        public Pause Pause { get; protected set; } = null;
        public Chord Chord { get; protected set; } = null;
    }
}