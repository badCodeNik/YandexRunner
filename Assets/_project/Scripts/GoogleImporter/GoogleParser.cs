using System;
using _project.Scripts.Game;
using _project.Scripts.Game.Configs;
using _project.Scripts.Services;
using _project.Scripts.Tools;
using GoogleImporter;
using UnityEngine;

namespace _project.Scripts.GoogleImporter
{
    public class GoogleParser : IGoogleSheetParser
    {
        private readonly Signal _signal;
        private WordConfig _currentWordConfig;

        public GoogleParser(Signal signal)
        {
            _signal = signal;
        }

        public void Parse(string header, string token)
        {
            _currentWordConfig = AllServices.Container.Single<WordConfig>();
            switch (header)
            {
                case "Term":
                    _currentWordConfig.term = token;
                    break;
                case "FirstTranslation":
                    _currentWordConfig.firstTranslation = token;
                    break;
                case "SecondTranslation":
                    _currentWordConfig.secondTranslation = token;
                    break;
                case "ThirdTranslation":
                    _currentWordConfig.thirdTranslation = token;
                    break;
                case "RightTranslation":
                    _currentWordConfig.rightTranslation = token;
                    break;

                default:
                    throw new Exception($"Invalid header : {header}");
            }

            _currentWordConfig.LanguageLibrary[_currentWordConfig.term] = new[]
            {
                _currentWordConfig.firstTranslation,
                _currentWordConfig.secondTranslation,
                _currentWordConfig.thirdTranslation,
                _currentWordConfig.rightTranslation
            };
            
            _signal.RegistryRaise(new GameSignals.OnConfigUpdated
            {
                Config = _currentWordConfig
            });
            
            
            var jsonForSaving = JsonUtility.ToJson(_currentWordConfig);
        }
    }
}