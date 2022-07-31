using GameplayAudioSystem.Storage;
using TileSystem;
using TileSystem.Tile;
using UnityEngine;

namespace GameplayAudioSystem 
{
    public class PlayingSystem 
    {
        private readonly AudioSourcePool _audioSourcePool;
        private readonly Piano _piano;
        private readonly PianoPlayer _pianoPlayer;
        private readonly PianoMelody _pianoMelody;
        private readonly TileSystem.TileSystem _tileSystem;

        public PlayingSystem(Transform audioPoolContainer, NoteSoundsStorage noteSoundsStorage, string melody, TileSystem.TileSystem tileSystem)
        {
            _audioSourcePool = new AudioSourcePool(audioPoolContainer);
            _piano = new Piano(noteSoundsStorage, _audioSourcePool);
            _pianoPlayer = new PianoPlayer(_piano);
            _pianoMelody = new PianoMelody(melody);
            _tileSystem = tileSystem;
            
            _pianoPlayer.SetMelody(_pianoMelody);
            _tileSystem.OnTilePress += TilePressHandler;
        }

        public void Run() =>  _tileSystem.Init(SpawnMap.GetSpawnMapFromMelody(_pianoMelody));
        
        public void Dispose() => _tileSystem.OnTilePress -= TilePressHandler;
        
        private void TilePressHandler(Tile Tile) 
        {
            _pianoPlayer.PlayOneChunk();
        }
    }
}