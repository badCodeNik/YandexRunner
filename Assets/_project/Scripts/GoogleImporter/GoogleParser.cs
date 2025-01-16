using System;
using _project.Scripts.Game;
using _project.Scripts.GoogleImporter;
using _project.Scripts.Tools;
using UnityEngine;

namespace GoogleImporter
{
    public class GoogleParser : IGoogleSheetParser
    {
        private readonly Signal _signal;
        private readonly Config _currentConfig;

        public GoogleParser(Signal signal, Config config)
        {
            _signal = signal;
            _currentConfig = config;
        }

        public void Parse(string header, string token)
        {
            switch (header)
            {
                case "Term":
                    _currentConfig.term = token;
                    break;
                case "FirstTranslation":
                    _currentConfig.firstTranslation = token;
                    break;
                case "SecondTranslation":
                    _currentConfig.secondTranslation = token;
                    break;
                case "ThirdTranslation":
                    _currentConfig.thirdTranslation = token;
                    break;
                case "RightTranslation":
                    _currentConfig.rightTranslation = token;
                    break;

                default:
                    throw new Exception($"Invalid header : {header}");
            }

            _currentConfig.LanguageLibrary[_currentConfig.term] = new[]
            {
                _currentConfig.firstTranslation,
                _currentConfig.secondTranslation,
                _currentConfig.thirdTranslation,
                _currentConfig.rightTranslation
            };
            
            _signal.RegistryRaise(new GameSignals.OnConfigUpdated
            {
                Config = _currentConfig
            });
            
            
            var jsonForSaving = JsonUtility.ToJson(_currentConfig);
        }
    }
}