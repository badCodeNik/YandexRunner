using _project.Scripts.Game.GameplayControllers;
using _project.Scripts.Game.GameRoot;
using _project.Scripts.Services;
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
            chosenWordController.Initialize(AllServices.Container.Single<Signal>());
            AllServices.Container.RegisterSingle(chosenWordController);
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