using UnityEngine;

namespace _project.Scripts.Services
{
    public class GameFactory
    {
        private readonly ResourceLoaderService _resourceLoaderService;

        public GameFactory(ResourceLoaderService resourceLoaderService)
        {
            Debug.Log("GameFactory before injecting");
            _resourceLoaderService = resourceLoaderService;
            Debug.Log("GameFactory");
        }
        
        public GameObject CreateGameObject(string path)
        {
            return _resourceLoaderService.LoadPrefab(path);
        }
        
        public GameObject CreateGameObjectAtPosition(string path, Vector3 position)
        {
            var prefab = _resourceLoaderService.LoadPrefab(path);
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }
    }
}