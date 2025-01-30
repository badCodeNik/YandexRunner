using _project.Scripts.Game.Entities;
using _project.Scripts.Services.Input;
using _project.Scripts.Tools;
using UnityEngine;

namespace _project.Scripts.Game.GameplayControllers
{
    public class HeroMoveController : MonoBehaviour
    {
        private Hero _hero;
        private bool _isMoving;
        private Position _position = Position.Middle;
        private InputService _inputService;
        private Signal _signal;

        public void Initialize(InputService inputService, Signal signal)
        {
            _signal = signal;
            _inputService = inputService;
            _signal.Subscribe<GameSignals.OnGameEnded>(OnSignal);
            _signal.Subscribe<GameSignals.OnGameStarted>(OnSignal);
            _signal.Subscribe<GameSignals.OnHeroSpawned>(OnSignal);
        }

        private void OnSignal(GameSignals.OnGameStarted data)
        {
            _inputService.EnableInput();
            _isMoving = true;
        }

        private void OnSignal(GameSignals.OnGameEnded data)
        {
            _isMoving = false;
            _hero.MoveComponent.Stop();
        }

        private void OnSignal(GameSignals.OnHeroSpawned data) => _hero = data.Hero;

        public void SwipeLeft()
        {
            if (_position == Position.Left) return;
            if (_position == Position.Right)
            {
                _hero.MoveComponent.MoveToCenter();
                _position = Position.Middle;
                return;
            }
            _hero.MoveComponent.MoveToLeft();
            _position--;
        }

        public void SwipeRight()
        {
            if (_position == Position.Right) return;
            if (_position == Position.Left)
            {
                _hero.MoveComponent.MoveToCenter();
                _position = Position.Middle;
                return;
            }
            _hero.MoveComponent.MoveToRight();
            _position++;
        }

        public void SwipeUp()
        {
            _hero.JumpComponent.Jump();
        }

        public void SwipeDown()
        {
            // Implement if needed
        }

        private void Update()
        {
            if (_hero == null || !_hero.IsInitialized) return;
            if (_isMoving) _hero.MoveComponent.Move();
            _hero.JumpComponent.Update();
        }
    }

    public enum Position
    {
        Left = 1,
        Middle = 2,
        Right = 3
    }
}