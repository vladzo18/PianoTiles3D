using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI 
{
    public class SongItemView : MonoBehaviour 
    {
       [SerializeField] private Image _songImage;
       [SerializeField] private TMP_Text _songArtistName;
       [SerializeField] private TMP_Text _songName;
       [SerializeField] private StarsBox _starsBox;
       [SerializeField] private Button _saveButton;
       [SerializeField] private GameObject _blockBox;

       public event Action OnPlayButtonClick;

       public void SetSongImage(Sprite sprite) => _songImage.sprite = sprite;
       
       public void SetSong(string songArtist, string songName) 
       {
           _songArtistName.text = songArtist;
           _songName.text = songName;
       }

       public void SetBlockStatus(bool status) => _blockBox.SetActive(status);
       
       public void SetProgress(int value) => _starsBox.SetStars(value);

       private void OnEnable() => 
           _saveButton.onClick.AddListener(() => OnPlayButtonClick?.Invoke());

       private void OnDisable() => _saveButton.onClick.RemoveAllListeners();
    }
}
