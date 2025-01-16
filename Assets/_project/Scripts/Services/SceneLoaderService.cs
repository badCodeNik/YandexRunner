using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace _project.Scripts.Services
{
    public class SceneLoaderService
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public IEnumerator LoadSceneAsync(string sceneName, Action onSceneLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == sceneName) yield break;
            
            var sceneLoadOperation = SceneManager.LoadSceneAsync(sceneName);
            while (sceneLoadOperation is { isDone: false })
            {
                yield return null;
            }

            onSceneLoaded?.Invoke();
        }
    }
}