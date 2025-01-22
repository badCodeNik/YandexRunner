using _project.Scripts.Game.GameRoot.UI;
using _project.Scripts.Services;
using _project.Scripts.Tools;
using UnityEngine;

namespace _project.Scripts.Game.GameplayControllers
{
    public class QuizController : MonoBehaviour
    {
        private const float TimeGapBetweenQuizes = 10f;
        private float timeToNextQuiz;
        private float _timer;
        private bool _isGameActive;
        private Signal _signal;
        private bool _isShowing;

        public void Initialize()
        {
            _signal = AllServices.Container.Single<Signal>();
            _signal.Subscribe<GameSignals.OnGameStarted>(OnSignal);
            _signal.Subscribe<GameSignals.OnGameEnded>(OnSignal);
            _signal.Subscribe<UISignals.OnTranslationChosen>(OnSignal);
            timeToNextQuiz = Random.Range(0, TimeGapBetweenQuizes);
        }

        private void OnSignal(UISignals.OnTranslationChosen data)
        {
            _isShowing = false;
        }

        private void Update()
        {
            if (!_isGameActive) return;

            if (_isShowing) return;
            _timer += Time.deltaTime;
            
            if (_timer >= timeToNextQuiz)
            {
                timeToNextQuiz = Random.Range(0, TimeGapBetweenQuizes);
                _timer -= timeToNextQuiz;
                _isShowing = true;
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