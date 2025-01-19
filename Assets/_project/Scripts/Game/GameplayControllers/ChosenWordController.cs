using _project.Scripts.Game.Entities;
using _project.Scripts.Game.GameRoot.UI;
using _project.Scripts.Tools;

namespace _project.Scripts.Game.GameplayControllers
{
    public class ChosenWordController
    {
        private Hero _hero;
        private Signal _signal;


        public void Initialize(Signal signal)
        {
            _signal = signal;
            _signal.Subscribe<GameSignals.OnHeroSpawned>(OnSignal);
            _signal.Subscribe<UISignals.OnTranslationChosen>(OnSignal);
        }
        
        private void OnSignal(GameSignals.OnHeroSpawned data)
        {
            _hero = data.Hero;
        }

        private void OnSignal(UISignals.OnTranslationChosen data)
        {
            if (data.ChosenTranslation == data.RightAnswer) return;
        }
    }
}