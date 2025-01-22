using System.Collections.Generic;
using _project.Scripts.Extentions;
using _project.Scripts.Services;
using UnityEngine;

namespace _project.Scripts.Game.Configs
{
    [CreateAssetMenu(fileName = "WordConfig", menuName = "Configs/WordConfig")]
    public class WordConfig : Config
    {
        public string term;
        public string firstTranslation;
        public string secondTranslation;
        public string thirdTranslation;
        public string rightTranslation;
        public Dictionary<string, string[]> LanguageLibrary = new();
        
        public (string, string[]) GetRandomCombination()
        {
            var random = LanguageLibrary.PopRandom();
            return (random.Key, random.Value);
        }

        public override void Initialize()
        {
            AllServices.Container.RegisterSingle(this);
        }
    }
}