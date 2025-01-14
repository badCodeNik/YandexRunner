using System;
using _project.Scripts.Game.GameRoot;
using _project.Scripts.Tools;
using UnityEngine;

namespace _project.Scripts.Game.Infrastructure.FSM
{
    public class Game : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private ServiceLocator _serviceLocator;
        private Coroutines _coroutines;
        private Signal _signal;
        private UIRootView _uiRootView;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            _serviceLocator = new GameObject("[SERVICE LOCATOR]").AddComponent<ServiceLocator>();
            DontDestroyOnLoad(_serviceLocator.gameObject);
            _signal = new Signal(true);
            _serviceLocator.RegisterInstance(_signal);
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            DontDestroyOnLoad(_coroutines.gameObject);

            var uiRootPrefab = Resources.Load<UIRootView>(Constants.Paths.UiRootViewPath);
            _uiRootView = Instantiate(uiRootPrefab);
            _uiRootView.Initialize(_signal);
            DontDestroyOnLoad(_uiRootView.gameObject);


            _gameStateMachine = new GameStateMachine(_serviceLocator, _signal, _coroutines, _uiRootView);
            _gameStateMachine.ChangeState<InitializeGameState>();
        }
        
    }
}