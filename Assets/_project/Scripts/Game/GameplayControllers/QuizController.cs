using System;
using _project.Scripts.Extentions;
using _project.Scripts.Game.Infrastructure;
using _project.Scripts.Tools;
using UnityEngine;

namespace _project.Scripts.Game.GameplayControllers
{
    public class QuizController : SignalListener<GameSignals.OnGameStarted, GameSignals.OnGameEnded>
    {
        [SerializeField] private float timeBetweenQuizes = 5f;
        private float _timer;
        private bool _isGameActive;
        private Signal _signal;

        private void Start()
        {
            _signal = ServiceLocator.Instance.GetInstance<Signal>();
        }

        private void Update()
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

        protected override void OnSignal(GameSignals.OnGameStarted data)
        {
            _isGameActive = true;
        }

        protected override void OnSignal(GameSignals.OnGameEnded data)
        {
            _isGameActive = false;
            ResetTimer();
        }
    }
}