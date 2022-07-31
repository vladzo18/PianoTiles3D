using System;
using Assets.Scripts.ObjectPooling;
using UnityEngine;

namespace TileSystem.Tile 
{
    [RequireComponent(typeof(TileClickBeholder), typeof(TileAnimator))]
    public class Tile : MonoBehaviour , IPoolable
    {
        public static event Action<Tile> OnTileClick;

        [SerializeField] private TileType _tileType;
        
        private TileClickBeholder _tileClickBeholder;

        public TileType TileType => _tileType;
        public int PlayNotationEntityCount { get; set; }
        public TileMover TileMover { get; private set; }
        public TileAnimator TileAnimator { get; private set; }

        private void Awake() 
        {
            _tileClickBeholder = this.GetComponent<TileClickBeholder>();
            TileAnimator = this.GetComponent<TileAnimator>();
            TileMover = new TileMover(this.transform);
        }

        private void Start() => _tileClickBeholder.OnClick += ClickPianoTileHandler;
        
        private void OnDestroy() => _tileClickBeholder.OnClick -= ClickPianoTileHandler;
        
        private void FixedUpdate() => TileMover.FixedUpdate();

        private void ResetTile() 
        {
            TileAnimator.Reset();
            _tileClickBeholder.Reset();
            TileMover.Stop();
            this.transform.position = Vector3.zero;
        }

        private void ClickPianoTileHandler() => OnTileClick?.Invoke(this);

        #region IPoolable
        public Transform Transform => this.transform;
        public GameObject GameObject => this.gameObject;
        public event Action<IPoolable> OnReturnToPool;
        public void Reset() 
        {
            ResetTile();
            OnReturnToPool?.Invoke(this);
        }
        #endregion
    }
}