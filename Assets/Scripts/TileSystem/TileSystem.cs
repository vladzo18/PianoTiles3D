using System;
using System.Collections.Generic;
using UnityEngine;

namespace TileSystem 
{
    public class TileSystem : MonoBehaviour 
    {
        [SerializeField] private TileSpawner _tileSpawner;
        [SerializeField] private TileCatcher _catcher;
        
        private bool isLastLeftRevert;
        private Dictionary<Tile.Tile, int> _tileIndexes;
        private int _indexCounter;
        private int _lastRevertedTileIndex;

        public event Action<Tile.Tile> OnTilePress; 

        private void Awake() => _tileIndexes = new Dictionary<Tile.Tile, int>();
            
        private void OnEnable() 
        {
            Tile.Tile.OnTileClick += TileClickHandler;
            _catcher.OnTileCatche += TileCatchHandler;
            _tileSpawner.OnTileSpawn += TileSpawnHandler;
        }

        private void OnDisable() 
        {
            Tile.Tile.OnTileClick -= TileClickHandler;
            _catcher.OnTileCatche -= TileCatchHandler;
            _tileSpawner.OnTileSpawn -= TileSpawnHandler;
        }

        public void Init(SpawnMap spawnMap) 
        {
            _tileSpawner.Init(spawnMap);
            _tileSpawner.Run();
        }
        
        private void TileClickHandler(Tile.Tile tile) 
        {
            if (!isLastLeftRevert) 
            {
                tile.TileAnimator.ReverseLeft();
                isLastLeftRevert = true;
            } 
            else 
            {
                tile.TileAnimator.ReverseRight();
                isLastLeftRevert = false;
            }

            OnTilePress?.Invoke(tile);
            _lastRevertedTileIndex = _tileIndexes[tile];
        }

        private void TileSpawnHandler(Tile.Tile tile) 
        {
            tile.TileMover.Run();
            _tileIndexes[tile] = _indexCounter++;
        }

        private void TileCatchHandler(Tile.Tile tile) => tile.Reset();
    }
}