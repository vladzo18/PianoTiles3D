using System;
using UnityEngine;

namespace UI 
{
    [Serializable]
    public class SongItemDataDescriptor 
    {
        [SerializeField] private string _authorName;
        [SerializeField] private string _songName;
        [SerializeField] private Sprite _songImage;

        public string AuthorName => _authorName;
        public string SongName => _songName;
        public Sprite SongImage => _songImage;
    }
}