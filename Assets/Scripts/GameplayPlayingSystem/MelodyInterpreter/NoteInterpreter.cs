using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GameplayAudioSystem.MelodyInterpreter 
{
    public class NoteInterpreter
    {
        private readonly Dictionary<string, NoteType> _noteNameTokens;
        private readonly Dictionary<string, OctaveType> _octaveTokens;
        private readonly DurationInterpreter _durationInterpreter;

        public NoteInterpreter(DurationInterpreter durationInterpreter) 
        {
            _noteNameTokens = new Dictionary<string, NoteType>();
            _octaveTokens = new Dictionary<string, OctaveType>();
            _durationInterpreter = durationInterpreter;
            
            FillNameTokensDictionary();
            FillOctaveTokensDictionary();
        }
        
        public Note InterpretNote(string token) 
        {
            string temp = string.Copy(token);
            string nameChunk, hightChunk, durationCunk;

            if (temp.Contains("#")) nameChunk = temp.Substring(0, 2);
            else nameChunk = temp.Substring(0, 1);

            Regex nameRegex = new Regex(@$"^{nameChunk}");
            temp = nameRegex.Replace(temp, string.Empty);
            hightChunk = temp[0].ToString();

            temp = temp.Replace(hightChunk, string.Empty);
            durationCunk = temp.ToString();

            if (string.IsNullOrEmpty(durationCunk)) durationCunk = "[INC]";
                
            return GetNote(_noteNameTokens[nameChunk], _octaveTokens[hightChunk], _durationInterpreter.InterpretDuration(durationCunk));
        }
        
        private Note GetNote(NoteType noteType, OctaveType octaveType, float duration) 
        {
            return new Note() 
            {
                NoteType = noteType,
                OctaveType = octaveType,
                Duration = duration
            };
        }
        
        private void FillNameTokensDictionary() 
        {
            _noteNameTokens.Add("C", NoteType.C);
            _noteNameTokens.Add("C#", NoteType.CSharp);
            _noteNameTokens.Add("D", NoteType.D);
            _noteNameTokens.Add("D#", NoteType.DSharp);
            _noteNameTokens.Add("E", NoteType.E);
            _noteNameTokens.Add("F", NoteType.F);
            _noteNameTokens.Add("F#", NoteType.FSharp);
            _noteNameTokens.Add("G", NoteType.G);
            _noteNameTokens.Add("G#", NoteType.GSharp);
            _noteNameTokens.Add("A", NoteType.A);
            _noteNameTokens.Add("A#", NoteType.ASharp);
            _noteNameTokens.Add("B", NoteType.B);
        }

        private void FillOctaveTokensDictionary() 
        {
            _octaveTokens.Add("0", OctaveType.SubContraOctave);
            _octaveTokens.Add("1", OctaveType.ContraOctave);
            _octaveTokens.Add("2", OctaveType.GreatOctave);
            _octaveTokens.Add("3", OctaveType.SmallOctave);
            _octaveTokens.Add("4", OctaveType.OneLineOctave);
            _octaveTokens.Add("5", OctaveType.TwoLineOctave);
            _octaveTokens.Add("6", OctaveType.ThreeLineOctave);
            _octaveTokens.Add("7", OctaveType.FourLineOctave);
        }
    }
}