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
        private readonly GameStateMachine _stateMachine;
        private readonly DiContainer _container;
        private readonly UIRootView _uiRootView;
        private readonly Signal _signal;

        public InitializeGameState(GameStateMachine stateMachine, DiContainer container, UIRootView uiRootView)
        {
            _stateMachine = stateMachine;
            _container = container;
            _uiRootView = uiRootView;
        }

        public void Enter()
        {
            Debug.Log("Enter InitializeGameState");
            var sceneName = SceneManager.GetActiveScene().name;

            if (sceneName != Constants.Scenes.BootstrapScene) return;

            RegisterGameServices();
            InitializeScenes();
            InitClasses();
            ConfigImportsMenu.LoadSheetsSettings();
            _stateMachine.ChangeState<LoadLevelState>();
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