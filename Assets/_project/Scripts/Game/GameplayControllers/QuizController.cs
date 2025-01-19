using _project.Scripts.Tools;
using UnityEngine;

namespace _project.Scripts.Game.GameplayControllers
{
    public class QuizController : MonoBehaviour
    {
        private const float TimeBetweenQuizes = 5f;
        private float _timer;
        private bool _isGameActive;
        private Signal _signal;
        
        public void Initialize(Signal signal)
        {
            _signal = signal;
            _signal.Subscribe<GameSignals.OnGameStarted>(OnSignal);
            _signal.Subscribe<GameSignals.OnGameEnded>(OnSignal);
        }

        private void Update()
        {
            if (!_isGameActive) return;

            _timer += Time.deltaTime;
            if (_timer >= TimeBetweenQuizes)
            {
                _timer -= TimeBetweenQuizes;
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