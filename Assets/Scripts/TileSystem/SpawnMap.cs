using System.Collections.Generic;
using GameplayAudioSystem;
using TileSystem.Tile;

namespace TileSystem 
{
    public class SpawnMap 
    {
        private readonly List<SpawnMapDescriptor> _positions;
        
        private int _currentPosition;
        
        private SpawnMap() 
        {
            _positions = new List<SpawnMapDescriptor>();
            _currentPosition = 0;
        }

        public SpawnMapDescriptor GetNextPosition() 
        {
            SpawnMapDescriptor position = _positions[_currentPosition];
            _currentPosition++;
            if (_currentPosition >= _positions.Count) _currentPosition = 0;
            return position;
        }
        
        public static SpawnMap GetSpawnMapFromMelody(PianoMelody pianoMelody) 
        {
            SpawnMap spawnMap = new SpawnMap();

            SpawnMapDescriptor one = new SpawnMapDescriptor(0, TileType.WholeNoteTile, 1);
            SpawnMapDescriptor two = new SpawnMapDescriptor(1, TileType.HalfNoteTile, 2);
            SpawnMapDescriptor three = new SpawnMapDescriptor(2, TileType.QuarterNoteTile, 1);
            SpawnMapDescriptor four = new SpawnMapDescriptor(3, TileType.EightNoteTile, 1);
            SpawnMapDescriptor five = new SpawnMapDescriptor(2, TileType.SixteenNoteTile, 1);
            
            spawnMap._positions.Add(one);
            spawnMap._positions.Add(two);
            spawnMap._positions.Add(three);
            spawnMap._positions.Add(four);
            spawnMap._positions.Add(five);

            return spawnMap;
        }
    }
}