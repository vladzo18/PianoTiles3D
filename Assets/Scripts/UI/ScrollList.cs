using UnityEngine;

namespace UI 
{
    public class ScrollList : MonoBehaviour 
    {
        [SerializeField] private Transform _songItemsContainer;
        [SerializeField] private SongItemView _songItemPrefab;
        [SerializeField] private SongItemDataStorage _songItemDataStorage;
        
        private void Start() 
        {
            for (int i = 0; i < _songItemDataStorage.SongItemDataDescriptors.Count; i++) 
            {
                SongItemView view = Instantiate(_songItemPrefab, _songItemsContainer);
                SongItemController controller = new SongItemController(view);
                controller.Initialize(_songItemDataStorage);
            }
        }
    }
}
