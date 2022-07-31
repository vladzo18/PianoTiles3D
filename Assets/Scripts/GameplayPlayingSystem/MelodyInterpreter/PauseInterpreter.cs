using System;
using System.Collections.Generic;

namespace GameplayAudioSystem.MelodyInterpreter 
{
    public class PauseInterpreter 
    {
        private readonly Dictionary<string, float> _durationTokens;
        
        public PauseInterpreter()
        {
            _durationTokens = new Dictionary<string, float>();
            FillDurationTokensDictionary();
        }

        public bool isPause(string token) => token.StartsWith("-");
        
        public Pause InterpretNote(string token) 
        {
            float duration = -1f;
            
            try 
            { 
                duration = _durationTokens[token];
            } 
            catch
            {
                throw new InvalidOperationException("Invalid Pause Interpretation");
            }

            return new Pause() { Duration = duration };
        }

        private void FillDurationTokensDictionary() 
        {
            _durationTokens.Add("-W", 1f);
            _durationTokens.Add("-H", 0.5f);
            _durationTokens.Add("-Q", 0.25f);
            _durationTokens.Add("-E", 0.125f);
            _durationTokens.Add("-S", 0.0625f);
        }
    }
}