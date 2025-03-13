using UnityEngine;

namespace _project.Scripts.Services
{
    public class GameFactory
    {
        private readonly ResourceLoaderService _resourceLoaderService;

        public GameFactory(ResourceLoaderService resourceLoaderService)
        {
            _resourceLoaderService = resourceLoaderService;
        }
        
        public GameObject CreateGameObject(string path)
        {
            var prefab =_resourceLoaderService.LoadPrefab(path);
            return Object.Instantiate(prefab);
        }
        
        public GameObject CreateGameObjectAtPosition(string path, Vector3 position)
        {
            var prefab = _resourceLoaderService.LoadPrefab(path);
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }
    }
}