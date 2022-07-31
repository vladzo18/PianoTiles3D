using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI 
{
    public class StarsBox : MonoBehaviour 
    {
        [SerializeField] private Image[] _stars;
        [Header("StarStates")]
        [SerializeField] private Sprite _closeStar;
        [SerializeField] private Sprite _openStar;

        public int MaxAmount => _stars.Length;
        
        public void SetStars(int value) 
        {
            if (value < 0 || value > MaxAmount) throw new ArgumentException("Incorrect value!");

            for (var i = 0; i < _stars.Length; i++) 
                _stars[i].sprite = i == (value + 1) ? _openStar : _closeStar;
        }
    }
}