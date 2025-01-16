using System;
using System.Collections.Generic;
using _project.Scripts.Game.Infrastructure.FSM;
using UnityEngine;
using Zenject;

public class GameStateMachine
{
    private readonly DiContainer _container;
    private readonly Dictionary<Type, ILevelState> _states = new();
    private ILevelState _currentState;

    public GameStateMachine(DiContainer container)
    {
        Debug.Log("GameStateMachine");
        _container = container;

        _states = new Dictionary<Type, ILevelState>()
        {
            [typeof(InitializeGameState)] = _container.Instantiate<InitializeGameState>(),
            [typeof(LoadLevelState)] = _container.Instantiate<LoadLevelState>(),
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