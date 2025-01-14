using UnityEngine;

namespace _project.Scripts.Extentions
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<T>();

                    if (_instance != null)
                    {
                        var allInstances = FindObjectsByType<T>(FindObjectsSortMode.None);
                        if (allInstances.Length > 1)
                        {
                            Debug.LogError($"There is more than one {typeof(T).Name} in the scene.");
                        }
                    }
                    else
                    {
                        // Если экземпляр не найден, создаем его
                        GameObject obj = new GameObject(typeof(T).Name);
                        _instance = obj.AddComponent<T>();
                        DontDestroyOnLoad(obj); // Опционально, если вы хотите сохранить объект между сценами
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else if (_instance != this)
            {
                Debug.LogError($"Another instance of {typeof(T).Name} already exists! Destroying this instance.");
                Destroy(gameObject);
            }
        }
    }
}