
using TMPro;
using UnityEngine;

namespace DefaultNamespace.HUD 
{
    public class ScoreCounter : MonoBehaviour 
    {
        [SerializeField] private TMP_Text _text;

        public int Value { get; set; }

        private void Start() => _text.text = Value.ToString();

        public void IncreseCounter() => _text.text = (++Value).ToString();
    }
}