using System.Collections;
using System.Threading.Tasks;
using _project.Scripts.Game.GameRoot;
using _project.Scripts.Services;
using GoogleImporter;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _project.Scripts.Game.Infrastructure.FSM
{
    public class InitializeGameState : ILevelState
    {
        private readonly GameStateMachine _stateMachine;

        public InitializeGameState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
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
            _stateMachine.UIRootView.ShowLoadingScreen();
            _stateMachine.UIRootView.ShowMainMenuPanel();
            _stateMachine.UIRootView.HideLoadingScreen();
        }

        private void RegisterGameServices()
        {
            _stateMachine.ServiceLocator.RegisterInstance(new SceneLoaderService());
            var resourceLoaderService = new ResourceLoaderService();
            _stateMachine.ServiceLocator.RegisterInstance(resourceLoaderService);
            _stateMachine.ServiceLocator.RegisterInstance(new GameFactory(resourceLoaderService));
        }

        private void InitClasses()
        {
            var gameplayInitializer = new GameplayInitializer(_stateMachine.UIRootView, _stateMachine.Signal);
            var gameStartController = new GameStarter(_stateMachine.UIRootView, gameplayInitializer);
        }

        public void Exit()
        {
        }
    }
}