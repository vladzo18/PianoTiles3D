using TileSystem.Tile;
using UnityEngine;

namespace DefaultNamespace.HUD 
{
    public class HUDSystem : MonoBehaviour
    {
        [SerializeField] private ScoreBar _scoreBar;
        [SerializeField] private ScoreCounter _scoreCounter;
        
        [SerializeField] private TileSystem.TileSystem _tileSystem;

        private int _counter;
        
        private void OnEnable() 
        {
            _tileSystem.OnTilePress += TilePressHandler;
        }

        private void OnDisable() 
        {
            _tileSystem.OnTilePress -= TilePressHandler;
        }

        private void TilePressHandler(Tile tile)
        {
            //_scoreBar.SetScore(5 * _counter);
            _counter++;
            _scoreCounter.IncreseCounter();
        }
    }
}