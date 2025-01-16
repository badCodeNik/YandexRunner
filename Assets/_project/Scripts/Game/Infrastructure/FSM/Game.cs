using UnityEngine;
using Zenject;

namespace _project.Scripts.Game.Infrastructure.FSM
{
    public class Game 
    {
        private GameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            ConfigureGame();
        }

        private void ConfigureGame()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            _gameStateMachine.ChangeState<InitializeGameState>();
            Debug.Log($"{_gameStateMachine}");
        }
    }
}