using System;
using System.Collections.Generic;
using _project.Scripts.Tools;

namespace _project.Scripts.Game.Infrastructure.FSM
{
    public class GameStateMachine
    {
        public Signal Signal { get; }
        private readonly Dictionary<Type, ILevelState> _states = new();
        private ILevelState _currentState;

        public GameStateMachine(Signal signal)
        {
            Signal = signal;
            _states = new Dictionary<Type, ILevelState>
            {
                [typeof(InitializeGameState)] = new InitializeGameState(this),
                [typeof(LoadLevelState)] = new LoadLevelState(),
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