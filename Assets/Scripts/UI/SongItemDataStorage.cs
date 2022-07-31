using System.Collections.Generic;
using UnityEngine;

namespace UI 
{
    [CreateAssetMenu(fileName = "SongItemDataStorage", menuName = "Storages/SongItemDataStorage", order = 0)]
    public class SongItemDataStorage : ScriptableObject 
    {
        [SerializeField] private List<SongItemDataDescriptor> _songItemDataDescriptors;

        public List<SongItemDataDescriptor> SongItemDataDescriptors => _songItemDataDescriptors;
    }
}