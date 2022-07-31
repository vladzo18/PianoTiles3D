namespace GameplayAudioSystem 
{
    public class Note : NotationEntity
    {
        public OctaveType OctaveType;
        public NoteType NoteType;

        public Note() => this.Note = this;
    }
}