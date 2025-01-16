using System;
using System.Collections.Generic;
using _project.Scripts.Game.Infrastructure.FSM;
using Zenject;

public class GameStateMachine
{
    private readonly DiContainer _container;
    private readonly Dictionary<Type, ILevelState> _states = new();
    private ILevelState _currentState;

    public GameStateMachine(DiContainer container)
    {
        _container = container;

        _states = new Dictionary<Type, ILevelState>()
        {
            [typeof(InitializeGameState)] = _container.Instantiate<InitializeGameState>(),
            [typeof(LoadLevelState)] = _container.Instantiate<LoadLevelState>(),
        };

        // Set the state machine reference after creation
        foreach (var state in _states.Values)
        {
            if (state is InitializeGameState initializeGameState)
            {
                initializeGameState.SetStateMachine(this);
            }
        }
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