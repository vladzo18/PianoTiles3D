namespace UI 
{
    public class SongItemController 
    {
        private readonly SongItemView _view;
        
        public SongItemController(SongItemView view) => _view = view;

        public void Initialize(SongItemDataStorage songItemDataStorage) 
        {
            foreach (var  descriptor in songItemDataStorage.SongItemDataDescriptors) 
            {
                _view.SetSong(descriptor.AuthorName, descriptor.SongName);
                _view.SetSongImage(descriptor.SongImage);
            }

            _view.OnPlayButtonClick += PlayButtonClickHandler;
        }

        public void Dispose() 
        {
            _view.OnPlayButtonClick -= PlayButtonClickHandler;
        }

        private void PlayButtonClickHandler() 
        {
            
        }
    }
}