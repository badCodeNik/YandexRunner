using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _project.Scripts.Extentions
{
    public static class DictionaryExtensions
    {
        public static KeyValuePair<TKey, TValue> PopRandom<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
#if UNITY_EDITOR
            if (dictionary.Count == 0)
                Debug.LogError("Пустой словарь");
#endif
            if (dictionary.Count == 1)
            {
                var singleEntry = new KeyValuePair<TKey, TValue>(dictionary.Keys.First(), dictionary.Values.First());
                dictionary.Clear();
                return singleEntry;
            }

            var randomIndex = Random.Range(0, dictionary.Count);

            var key = new List<TKey>(dictionary.Keys)[randomIndex];

            var value = dictionary[key];
            dictionary.Remove(key);

            return new KeyValuePair<TKey, TValue>(key, value);
        }
    }
}