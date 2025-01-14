using _project.Scripts.Extentions;
using _project.Scripts.Game.Entities;
using _project.Scripts.Game.GameRoot.UI;

namespace _project.Scripts.Game.GameplayControllers
{
    public class ChosenWordController : SignalListener<GameSignals.OnHeroSpawned, UISignals.OnTranslationChosen>
    {
        private Hero _hero;

        protected override void OnSignal(GameSignals.OnHeroSpawned data)
        {
            _hero = data.Hero;
        }

        protected override void OnSignal(UISignals.OnTranslationChosen data)
        {
            if (data.ChosenTranslation == data.RightAnswer) return;
        }
    }
}