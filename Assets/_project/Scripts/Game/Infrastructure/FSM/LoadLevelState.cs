using _project.Scripts.Game.GameplayControllers;
using _project.Scripts.Services;

namespace _project.Scripts.Game.Infrastructure.FSM
{
    public class LoadLevelState : ILevelState
    {
        private readonly SceneLoaderService _sceneLoaderService;
        private QuizController _quizController;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoaderService sceneLoaderService)
        {
            _sceneLoaderService = sceneLoaderService;
        }

        public void Enter()
        {
            _sceneLoaderService.LoadScene(Constants.Scenes.GameplayScene);
        }


        public void Exit()
        {
        }
    }
}