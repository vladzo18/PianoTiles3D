using System;
using UnityEngine;

namespace TileSystem 
{
    [RequireComponent(typeof(Collider))]
    public class TileCatcher : MonoBehaviour 
    {
        public event Action<Tile.Tile> OnTileCatche;
        
        private void OnTriggerEnter(Collider other) 
        {
            Tile.Tile tile = other.gameObject.GetComponent<Tile.Tile>();
            if (tile) OnTileCatche?.Invoke(tile);
        }
    }
}