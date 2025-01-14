using System;
using System.Collections.Generic;
using _project.Scripts.Extentions;
using UnityEngine;

namespace _project.Scripts.Game.Infrastructure
{
    public class ServiceLocator : Singleton<ServiceLocator>
    {
        private readonly Dictionary<Type, object> _services = new();
        [field: SerializeField] private List<string> Services { get; set; } = new();

        public void RegisterInstance<T>(T instance, bool overwrite = false) where T : class
        {
            var type = typeof(T);
            if (_services.ContainsKey(type) && !overwrite)
            {
                Debug.LogError($"There is already a service registered for {type}");
                return;
            }

            _services[type] = instance;
            Services.Add(instance.ToString());
            Debug.Log($"Registered service: {_services[type]}");
        }

        public T GetInstance<T>() where T : class
        {
            var type = typeof(T);
            if (_services.TryGetValue(type, out var instance))
            {
                return instance as T;
            }

            Debug.LogError($"There is no service registered for {type}");
            return default;
        }

        public void UnregisterService<T>() where T : class
        {
            var type = typeof(T);
            if (_services.Remove(type))
            {
                Debug.Log($"Unregistered service: {type.Name}");
            }
            else
            {
                Debug.LogWarning($"No service found to unregister for {type.Name}");
            }
        }
    }
}