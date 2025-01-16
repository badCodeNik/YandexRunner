using _project.Scripts.Game.GameRoot;
using _project.Scripts.Services;
using _project.Scripts.Tools;
using GoogleImporter;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _project.Scripts.Game.Infrastructure.FSM
{
    public class InitializeGameState : ILevelState
    {
        private GameStateMachine _stateMachine;
        private readonly DiContainer _container;
        private readonly UIRootView _uiRootView;
        private readonly GoogleSheetsImporter _googleSheetsImporter;

        public InitializeGameState(
            DiContainer container,
            UIRootView uiRootView,
            GoogleSheetsImporter googleSheetsImporter)
        {
            _container = container;
            _uiRootView = uiRootView;
            _googleSheetsImporter = googleSheetsImporter;
        }
        
        public void SetStateMachine(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            Debug.Log("Enter InitializeGameState");
            var sceneName = SceneManager.GetActiveScene().name;

            if (sceneName != Constants.Scenes.BootstrapScene) return;
            ParseGoogleSheet();
            //RegisterGameServices();
            InitializeScenes();
            //InitClasses();
            _stateMachine.ChangeState<LoadLevelState>();
        }

        private async void ParseGoogleSheet()
        {
            await _googleSheetsImporter.DownloadAndParseSheet();
        }

        private void InitializeScenes()
        {
            _uiRootView.ShowLoadingScreen();
            _uiRootView.ShowMainMenuPanel();
            _uiRootView.HideLoadingScreen();
        }

        private void RegisterGameServices()
        {
            _container.Bind<SceneLoaderService>().AsSingle();
            _container.Bind<ResourceLoaderService>().AsSingle();
            _container.Bind<GameFactory>().AsSingle();
        }

        private void InitClasses()
        {
            _container.Bind<GameplayInitializer>().AsSingle();
            _container.Bind<GameStarter>().AsSingle();
        }

        public void Exit()
        {
        }
    }
}