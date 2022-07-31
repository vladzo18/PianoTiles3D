using System.Collections.Generic;
using TileSystem.Tile;
using UnityEngine;

namespace TileSystem 
{
    [CreateAssetMenu(fileName = "TilePrefabStorage", menuName = "Storages/TilePrefabStorage", order = 0)]
    public class TilePrefabStorage : ScriptableObject 
    {
        [SerializeField] private List<Tile.Tile> _tilePrefabes;

        public Tile.Tile GetPrefab(TileType tileType) 
        {
            Tile.Tile tile = _tilePrefabes.Find(t => t.TileType == tileType);
            return tile;
        }
    }
}