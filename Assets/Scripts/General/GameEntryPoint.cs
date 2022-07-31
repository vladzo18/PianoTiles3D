using GameplayAudioSystem;
using GameplayAudioSystem.Storage;
using UnityEngine;

namespace General 
{
    public class GameEntryPoint : MonoBehaviour 
    {
        [SerializeField] private NoteSoundsStorage _NoteSoundsStorage;
        [SerializeField] private Transform _AudioSourcesContainer;
        
        [SerializeField] private TileSystem.TileSystem _tileSystem;
        private PlayingSystem _playingSystem;
        
        private void Awake() 
        {
            string melody = "(E1[W],E2[W],B2[W],E3[W])[W];-W;E3[Q];(E3[W],E1[W])[W];D3[Q];E3[W];F3[W];(G3[W],G1[W])[W];F3[W];E3[W];D3[W];C3[W];E3[W];B2[W];E3[W];A2[W];A2[W]";
           _playingSystem = new PlayingSystem(_AudioSourcesContainer, _NoteSoundsStorage, melody, _tileSystem);
        }

        private void Start() 
        {
            _playingSystem.Run();
        }

        private void OnDestroy() 
        {
            _playingSystem.Dispose();
        }
    }
}