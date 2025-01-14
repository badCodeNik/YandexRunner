using System;
using _project.Scripts.Extentions;
using _project.Scripts.Game.Entities.Components;
using _project.Scripts.Game.GameRoot.UI;
using _project.Scripts.Game.Infrastructure;
using _project.Scripts.Services.Input;

namespace _project.Scripts.Game.GameplayControllers
{
    public class InputController : SignalListener<GameSignals.QuizStarted, UISignals.OnTranslationChosen>
    {
        private InputService _input;

        private void Start()
        {
            _input = ServiceLocator.Instance.GetInstance<InputService>();
        }

        protected override void OnSignal(GameSignals.QuizStarted data)
        {
            _input.DisableInput();
        }

        protected override void OnSignal(UISignals.OnTranslationChosen data)
        {
            _input.EnableInput();
        }
    }
}