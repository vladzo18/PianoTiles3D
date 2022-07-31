using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.HUD 
{
    [RequireComponent(typeof(Slider))]
    public class ScoreBar : MonoBehaviour 
    {
        [SerializeField] private ScoreStar[] _scoreStars;
        
        private Slider _slider;
        private RectTransform _transform;

        private const int _maxValue = 100;

        private void Awake()
        {
            _slider = this.GetComponent<Slider>();
            _transform = this.GetComponent<RectTransform>();
            _slider.maxValue = _maxValue;
        }

        public void SetScore(int value) 
        {
            if (value < 0 || value > _maxValue) throw new ArgumentException("Invalid value");
            
            _slider.value = value;
            
            CheckStars(value);
        }

        private void CheckStars(int value) 
        {
            for (int i = 0; i < _scoreStars.Length; i++) 
            {
                bool isFill = value >= Mathf.Abs((_maxValue / _transform.rect.width) * (_scoreStars[i].RectTransform.offsetMin.x + _scoreStars[i].RectTransform.rect.width / 2));
                _scoreStars[i].SetStatus(isFill);
            }
        }
    }
}