using System.Collections.Generic;
using _project.Scripts.Game.Configs;
using _project.Scripts.Game.GameplayControllers;
using _project.Scripts.Game.GameRoot;
using _project.Scripts.GoogleImporter;
using _project.Scripts.Services;
using _project.Scripts.Services.Services;
using _project.Scripts.Tools;
using GoogleImporter;
using UnityEngine;
using Config = _project.Scripts.Game.Configs.Config;

namespace _project.Scripts.Game.Infrastructure.FSM
{
    public class CompositionRoot : MonoBehaviour
    {
        [SerializeField] private CameraController cameraController;
        [SerializeField, SerializeReference] private List<Config> configs;
        private GameStateMachine _gameStateMachine;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            AppConfigurator.Configure();
            
            var signal = new Signal(true);
            var uiRootPrefab = Resources.Load<UIRootView>(Constants.Paths.UiRootViewPath);
            var uiRootView = Instantiate(uiRootPrefab);
            uiRootView.Initialize(signal);
            DontDestroyOnLoad(uiRootView.gameObject);

            IGoogleSheetParser parser = new GoogleParser(signal);
            var googleSheetsImporter = new GoogleSheetsImporter(parser);
            var resourceLoaderService = new ResourceLoaderService();
            
            DependencyRegistry.RegisterDependencies(
                signal,
                uiRootView,
                parser,
                googleSheetsImporter,
                resourceLoaderService,
                cameraController,
                this
            );

            foreach (var config in configs)
            {
                config.Initialize();
            }
            

            _gameStateMachine = new GameStateMachine(signal);
            _gameStateMachine.ChangeState<InitializeGameState>();
        }
        
    }
}