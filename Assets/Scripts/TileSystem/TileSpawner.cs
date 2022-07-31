using System;
using System.Collections;
using Assets.Scripts.ObjectPooling;
using UnityEngine;

namespace TileSystem
{
    public class TileSpawner : MonoBehaviour 
    {
        [SerializeField] private TilePrefabStorage _tilePrefab;

        public event Action<Tile.Tile> OnTileSpawn;

        private ObjectPool _objectPool;
        private SpawnMap _spawnMap;
        private Coroutine _spawnCoroutine;
        
        private void OnDestroy() => StopCoroutine(_spawnCoroutine);

        public void Init(SpawnMap spawnMap) 
        {
            _spawnMap = spawnMap;
            _objectPool = ObjectPool.Instance;
        }

        public void Run() => _spawnCoroutine = StartCoroutine(SpawnerRoutine());
        
        private IEnumerator SpawnerRoutine() 
        {
            while (true) 
            {
                SpawnMapDescriptor descriptor = _spawnMap.GetNextPosition();
                Tile.Tile tile = _objectPool.GetObject(_tilePrefab.GetPrefab(descriptor.TileType));
                tile.PlayNotationEntityCount = descriptor.PlayNotationEntityCount;
                tile.transform.SetParent(transform);
                tile.transform.position = new Vector3(descriptor.Position,tile.transform.position.y , tile.transform.position.z);
                OnTileSpawn?.Invoke(tile);
                
                yield return new WaitForSeconds((tile.transform.lossyScale.z / tile.TileMover.MovementSpeed) * Time.fixedDeltaTime);
            }
        }
    }
}