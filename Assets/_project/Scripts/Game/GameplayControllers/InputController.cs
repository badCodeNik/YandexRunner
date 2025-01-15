using _project.Scripts.Extentions;
using _project.Scripts.Game.GameRoot.UI;
using _project.Scripts.Services.Input;
using _project.Scripts.Tools;
using Zenject;

namespace _project.Scripts.Game.GameplayControllers
{
    public class InputController
    {
        private InputService _input;
        private Signal _signal;

        [Inject]
        public void Construct(Signal signal, InputService inputService)
        {
            _signal = signal;
            _input = inputService;
            _signal.Subscribe<GameSignals.QuizStarted>(OnSignal);
            _signal.Subscribe<UISignals.OnTranslationChosen>(OnSignal);
        }

        private void OnSignal(GameSignals.QuizStarted data)
        {
            _input.DisableInput();
        }

        private void OnSignal(UISignals.OnTranslationChosen data)
        {
            _input.EnableInput();
        }
    }
}