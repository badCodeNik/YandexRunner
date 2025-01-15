using _project.Scripts.Extentions;
using _project.Scripts.Game.Configs;
using _project.Scripts.Game.Entities;
using _project.Scripts.Game.GameRoot;
using _project.Scripts.Services;
using _project.Scripts.Tools;

namespace _project.Scripts.Game.Infrastructure
{
    public class GameplayInitializer
    {
        private readonly GameFactory _gameFactory;
        private readonly UIRootView _uiRootView;
        private readonly Signal _signal;
        private readonly LevelConfig _levelConfig;
        private Hero _hero;

        public GameplayInitializer(UIRootView uiRootView, Signal signal, GameFactory gameFactory)
        {
            _uiRootView = uiRootView;
            _signal = signal;
            _gameFactory = gameFactory;
            _levelConfig = uiRootView.LevelConfig;
        }

        public void StartGameplay()
        {
            _uiRootView.HideMainMenuPanel();
            ActivateTapPanel();
            SpawnHero();
        }

        private void ActivateTapPanel()
        {
            _uiRootView.ShowTapPanel();
        }

        private void SpawnHero()
        {
            if (_hero == null)
            {
                _hero = _gameFactory
                    .CreateGameObjectAtPosition(Constants.Paths.HeroPath, _levelConfig.LevelHeroSpawnPoint.position)
                    .GetComponent<Hero>();
            }
            else _hero.transform.position = _levelConfig.LevelHeroSpawnPoint.position;

            _hero.Initialize(_signal);

            _signal.RegistryRaise(new GameSignals.OnHeroSpawned
            {
                Hero = _hero
            });
        }
        
    }
}