using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TileSystem.Tile 
{
    public class TileClickBeholder : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnClick;

        private bool isClicked;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (isClicked) return;
            OnClick?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData) => isClicked = true;
        
        public void Reset() => isClicked = false;
    }
}