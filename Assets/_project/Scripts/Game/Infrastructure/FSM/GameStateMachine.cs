using System;
using System.Collections.Generic;
using _project.Scripts.Game.GameRoot;
using _project.Scripts.Tools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _project.Scripts.Game.Infrastructure.FSM
{
    public class GameStateMachine
    {
        private readonly Coroutines _coroutines;
        public ServiceLocator ServiceLocator { get; }
        public Signal Signal { get; }
        public Coroutines Coroutines { get; }
        public UIRootView UIRootView { get; }
        private readonly Dictionary<Type, ILevelState> _states = new();
        private ILevelState _currentState;

        public GameStateMachine(ServiceLocator serviceLocator, Signal signal, Coroutines coroutines,
            UIRootView uiRootView)
        {
            ServiceLocator = serviceLocator;
            Signal = signal;
            Coroutines = coroutines;
            UIRootView = uiRootView;
            _states = new Dictionary<Type, ILevelState>()
            {
                [typeof(InitializeGameState)] = new InitializeGameState(this),
                [typeof(LoadLevelState)] = new LoadLevelState(this),
            };
        }

        public void ChangeState<TState>() where TState : ILevelState
        {
            if (_states.TryGetValue(typeof(TState), out var state))
            {
                _currentState?.Exit();
                _currentState = state;
                _currentState.Enter();
            }
        }

    }
}