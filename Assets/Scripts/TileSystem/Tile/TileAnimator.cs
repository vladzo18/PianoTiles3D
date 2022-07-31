using System;
using UnityEngine;

namespace TileSystem.Tile 
{
    [RequireComponent(typeof(Animator), typeof(Renderer))]
    public class TileAnimator : MonoBehaviour
    {
        private static readonly int IdleHash = Animator.StringToHash("Tile");
        private static readonly int RevertTileLeftHash = Animator.StringToHash("TileRevertLeft");
        private static readonly int RevertTileRightHash = Animator.StringToHash("TileRevertRight");

        private Animator _animator;
        private Color _defaultMaterialColor;
        private Material _material;
        
        public event Action OnAnimationEnd;
        
        private void Awake() 
        {
            _animator = this.GetComponent<Animator>();
            _material = this.GetComponent<Renderer>().material;
            _defaultMaterialColor = _material.color;
        }
        
        public void ReverseLeft() 
        {
            _animator.Play(RevertTileLeftHash);
            _material.color = Color.gray;
        }

        public void ReverseRight() 
        {
            _animator.Play(RevertTileRightHash);
            _material.color = Color.gray;
        }

        public void Reset() 
        {
            _animator.Play(IdleHash);
            _material.color = _defaultMaterialColor;
        }

        //AnimationEvent Call
        private void OnAnimationEndHandler() => OnAnimationEnd?.Invoke();
    }
}