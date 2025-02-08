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

        private void Update()
        {
            if (_hero == null || !_hero.IsInitialized) return;
            if (_isMoving) _hero.MoveComponent.Move(SimpleInput.GetAxis("Horizontal"));
        }
    }

}