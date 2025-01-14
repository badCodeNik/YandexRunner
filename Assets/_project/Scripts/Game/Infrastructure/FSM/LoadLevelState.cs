using _project.Scripts.Game.GameplayControllers;
using _project.Scripts.Services;
using _project.Scripts.Services.Input;
using UnityEngine;

namespace _project.Scripts.Game.Infrastructure.FSM
{
    public class LoadLevelState : ILevelState
    {
        private readonly GameStateMachine _stateMachine;
        private QuizController _quizController;

        public LoadLevelState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            var sceneLoaderService = _stateMachine.ServiceLocator.GetInstance<SceneLoaderService>();
            sceneLoaderService.LoadScene(Constants.Scenes.GameplayScene);
            RegisterGameplayServices();
        }
        

        private void RegisterGameplayServices()
        {
            _stateMachine.ServiceLocator.RegisterInstance(new InputService());
        }


        public void Exit()
        {
        }
    }
}