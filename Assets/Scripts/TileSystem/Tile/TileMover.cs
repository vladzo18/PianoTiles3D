using UnityEngine;

namespace TileSystem.Tile 
{
    public class TileMover 
    {
        private readonly Transform _transform;
        private bool _canMove;

        public float MovementSpeed { get; set; }

        public TileMover(Transform transform) 
        {
            _transform = transform;
            MovementSpeed = 0.05f;
        }

        public void FixedUpdate() 
        {
            if (!_canMove) return;
            _transform.localPosition = new Vector3(_transform.localPosition.x, _transform.localPosition.y, _transform.localPosition.z - MovementSpeed);
        }

        public void Run() => _canMove = true;
        
        public void Stop() => _canMove = false;
    }
}