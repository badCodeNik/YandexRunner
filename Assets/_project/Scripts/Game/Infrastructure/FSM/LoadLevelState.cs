using _project.Scripts.Game.GameplayControllers;
using _project.Scripts.Game.GameRoot;
using _project.Scripts.Services;
using _project.Scripts.Services.Services;
using _project.Scripts.Tools;

namespace _project.Scripts.Game.Infrastructure.FSM
{
    public class LoadLevelState : ILevelState
    {
        private readonly SceneLoaderService _sceneLoaderService;
        private QuizController _quizController;

        public LoadLevelState()
        {
            _sceneLoaderService = AllServices.Container.Single<SceneLoaderService>();
        }

        public void Enter()
        {
            InitControllers();
            InitClasses();
        }

        private void InitControllers()
        {
            var chosenWordController = new ChosenWordController();
            var signal = AllServices.Container.Single<Signal>();
            chosenWordController.Initialize(signal);
            ScoreService.Initialize(signal);
        }


        private void InitClasses()
        {
            var gameplayInitializer = new GameplayInitializer();
            var gameStarter = new GameStarter(gameplayInitializer);
        }

        public void Exit()
        {
        }
    }
}