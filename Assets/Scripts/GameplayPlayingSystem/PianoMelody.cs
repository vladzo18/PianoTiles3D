using System;
using System.Collections.Generic;

namespace GameplayAudioSystem 
{
    public class PianoMelody 
    {
        private readonly MelodyInterpreter.MelodyInterpreter _melodyInterpreter;
        private readonly List<NotationEntity> _notationEntities;

        public int NotationEntityCount => _notationEntities.Count;

        public PianoMelody(string melodyText) 
        {
            _melodyInterpreter = new MelodyInterpreter.MelodyInterpreter();
            _melodyInterpreter.SetMelody(melodyText);
            _notationEntities = _melodyInterpreter.GetMelody();
        }

        public NotationEntity GetNotationEntityBy(int index) 
        {
            if (index < 0 || index > NotationEntityCount) throw new ArgumentException($"Invalid {nameof(index)} value");
            return _notationEntities[index];
        }
    }
}