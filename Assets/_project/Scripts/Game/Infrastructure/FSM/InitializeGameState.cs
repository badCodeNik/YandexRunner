using System.Threading.Tasks;
using _project.Scripts.Game.GameplayControllers;
using _project.Scripts.Game.GameRoot;
using _project.Scripts.Services;
using _project.Scripts.Services.Input;
using _project.Scripts.Tools;
using GoogleImporter;
using Unity.VisualScripting;

namespace _project.Scripts.Game.Infrastructure.FSM
{
    public class InitializeGameState : ILevelState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly UIRootView _uiRootView;
        private readonly GoogleSheetsImporter _googleSheetsImporter;

        public InitializeGameState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _uiRootView = AllServices.Container.Single<UIRootView>();
            _googleSheetsImporter = AllServices.Container.Single<GoogleSheetsImporter>();;
        }
        

        public void Enter()
        {
            ParseGoogleSheet();
            InitializeScenes();
            InitializeClasses();
            _stateMachine.ChangeState<LoadLevelState>();
        }

        private void InitializeClasses()
        {
            var signal = AllServices.Container.Single<Signal>();
            var inputService = new InputService();
            var inputController = new InputController(signal, inputService);
            var heroMoveController = AllServices.Container.Single<CompositionRoot>().AddComponent<HeroMoveController>();
            heroMoveController.Initialize(inputService, signal);
            AllServices.Container.Single<CameraController>().Initialize(signal);
        }

        private async void ParseGoogleSheet()
        {
            await _googleSheetsImporter.DownloadAndParseSheet();
        }

        private async void InitializeScenes()
        {
            _uiRootView.ShowLoadingScreen();
            await Task.Delay(500);
            _uiRootView.ShowMainMenuPanel();
            _uiRootView.HideLoadingScreen();
        }


        public void Exit()
        {
        }
    }
}