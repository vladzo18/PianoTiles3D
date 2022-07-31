using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.HUD 
{
    public class ScoreStar : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private RectTransform _rectTransform;

        public RectTransform RectTransform => _rectTransform;
        
        public void SetStatus(bool status) => _image.color = status ? Color.white : Color.black;
    }
}