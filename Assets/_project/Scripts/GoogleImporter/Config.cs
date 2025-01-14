using System;
using System.Collections.Generic;
using _project.Scripts.Extentions;

namespace _project.Scripts.GoogleImporter
{
    [Serializable]
    public class Config
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
    }
}