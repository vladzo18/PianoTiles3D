using System.Collections.Generic;

namespace GameplayAudioSystem.MelodyInterpreter 
{
    public class DurationInterpreter 
    {
        private readonly Dictionary<string, float> _durationTokens;

        public DurationInterpreter() 
        {
            _durationTokens = new Dictionary<string, float>();
            FillDurationTokensDictionary(); 
        }

        public float InterpretDuration(string token) => _durationTokens[token];
        
        private void FillDurationTokensDictionary() 
        {
            _durationTokens.Add("[W]", 1f);
            _durationTokens.Add("[H]", 0.5f);
            _durationTokens.Add("[Q]", 0.25f);
            _durationTokens.Add("[E]", 0.125f);
            _durationTokens.Add("[S]", 0.0625f);
            _durationTokens.Add("[INC]", -1f);
        }
    }
}