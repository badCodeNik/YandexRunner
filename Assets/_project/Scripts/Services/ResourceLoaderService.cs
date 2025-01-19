using UnityEngine;

namespace _project.Scripts.Services
{
    public class ResourceLoaderService
    {
        public ResourceLoaderService()
        {
            Debug.Log("ResourceLoaderService created");
        }

        public Object Load(string path)
        {
            return Resources.Load(path);
        }

        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }

        public GameObject LoadPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }
    }
}