using _project.Scripts.Game.Configs;
using _project.Scripts.Game.Entities;
using _project.Scripts.Game.GameRoot;
using _project.Scripts.Services;
using _project.Scripts.Tools;
using UnityEngine;

namespace _project.Scripts.Game.Infrastructure
{
    public class GameplayInitializer
    {
        private readonly GameFactory _gameFactory;
        private readonly UIRootView _uiRootView;
        private readonly Signal _signal;
        private readonly LevelConfig _levelConfig;
        private Hero _hero;

        public GameplayInitializer()
        {
            _uiRootView = AllServices.Container.Single<UIRootView>();
            _signal = AllServices.Container.Single<Signal>();
            _gameFactory = AllServices.Container.Single<GameFactory>();
            _levelConfig = AllServices.Container.Single<LevelConfig>();
        }

        public void StartGameplay()
        {
            _uiRootView.HideMainMenuPanel();
            _uiRootView.ActivateScore();
            InitializeLevel();
            SpawnHero();
            ActivateTapPanel();
        }

        private void InitializeLevel()
        {
            GameObject floor = _gameFactory.CreateGameObject(Constants.Paths.FloorPath);
            GameObject finish = _gameFactory.CreateGameObject(Constants.Paths.FinishPath);
            _levelConfig.plane = floor;
            _levelConfig.finish = finish;
            _levelConfig.plane.transform.localScale = new Vector3(_levelConfig.levelWidth, 0, _levelConfig.levelLength);
            var collider = _levelConfig.plane.GetComponent<BoxCollider>();
            if (collider != null)
            {
                Vector3 planeSize = collider.size;
                float planeLength = planeSize.z * _levelConfig.plane.transform.localScale.z;
                float startZ = _levelConfig.plane.transform.position.z - (planeLength / 2);
                _levelConfig.LevelHeroSpawnPoint = new Vector3(0, _levelConfig.plane.transform.position.y + 0.5f, startZ);
                _levelConfig.finish.transform.position = new Vector3(
                    0,
                    _levelConfig.plane.transform.position.y + 0.5f,
                    _levelConfig.plane.transform.position.z + planeLength / 2);
            }
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
                    .CreateGameObjectAtPosition(Constants.Paths.HeroPath, _levelConfig.LevelHeroSpawnPoint)
                    .GetComponent<Hero>();
            }
            else _hero.transform.position = _levelConfig.LevelHeroSpawnPoint;

            _hero.Initialize(_signal);

            _signal.RegistryRaise(new GameSignals.OnHeroSpawned
            {
                Hero = _hero
            });
        }
    }
}