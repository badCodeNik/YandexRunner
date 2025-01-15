using System;
using _project.Scripts.Extentions;
using _project.Scripts.Game.Infrastructure;
using _project.Scripts.Tools;
using UnityEngine;
using UnityEngine.Timeline;
using Zenject;

namespace _project.Scripts.Game.GameplayControllers
{
    public class QuizController : ITickable
    {
        [SerializeField] private float timeBetweenQuizes = 5f;
        private float _timer;
        private bool _isGameActive;
        private Signal _signal;


        [Inject]
        public void Construct(Signal signal)
        {
            _signal = signal;
            _signal.Subscribe<GameSignals.OnGameStarted>(OnSignal);
            _signal.Subscribe<GameSignals.OnGameEnded>(OnSignal);
        }

        public void Tick()
        {
            if (!_isGameActive) return;

            _timer += Time.deltaTime;
            if (_timer >= timeBetweenQuizes)
            {
                _timer -= timeBetweenQuizes;
                _signal.RegistryRaise(new GameSignals.QuizStarted());
            }
        }


        private void ResetTimer()
        {
            _timer = 0;
        }

        private void OnSignal(GameSignals.OnGameStarted data)
        {
            _isGameActive = true;
        }

        private void OnSignal(GameSignals.OnGameEnded data)
        {
            _isGameActive = false;
            ResetTimer();
        }
    }
}