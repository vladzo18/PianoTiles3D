using TileSystem.Tile;

namespace TileSystem 
{
    public class SpawnMapDescriptor 
    {
        public int Position { get; private set; }
        public TileType TileType { get; private set; }
        public int PlayNotationEntityCount { get; private set; }

        public SpawnMapDescriptor(int position, TileType tileType, int playNotationEntityCount) 
        {
            Position = position;
            TileType = tileType;
            PlayNotationEntityCount = playNotationEntityCount;
        }
    }
}