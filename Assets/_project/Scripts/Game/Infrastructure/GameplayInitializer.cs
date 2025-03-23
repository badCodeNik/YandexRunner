using System;
using System.Collections.Generic;
using _project.Scripts.Game.Configs;
using _project.Scripts.Game.Entities;
using _project.Scripts.Game.GameRoot;
using _project.Scripts.Game.Obstacles;
using _project.Scripts.Services;
using _project.Scripts.Tools;
using UnityEngine;
using Random = UnityEngine.Random;

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
            ActivateTapPanel();
            InitializeLevel();
            SpawnHero();
        }

        private void InitializeLevel()
        {
            InitializeAndPlaceFloor();
            InitializeAndPlaceWordFence();
            InitializeSpawnPlaces();
        }

        private void InitializeSpawnPlaces()
        {
            var spawnPlaces = new SpawnPlace[3];
            int startPos = 10;
            int rangeLength = 22;
            int step = 25;
            var spawnRange = Random.Range(_levelConfig.obstaclesSettings.minObstaclesToSpawnCount, 
                _levelConfig.obstaclesSettings.maxObstaclesToSpawnCount);
            var sharedHealth = _levelConfig.obstaclesSettings.obstaclesHealth;
            float[] healthDistribution = { 0.2f, 0.3f, 0.5f }; 
            for (int i = 0; i < 3; i++)
            {
                Range range = new()
                {
                    from = startPos + i * step,
                    to = startPos + i * step + rangeLength
                };
                
                int healthForSpawnPlace = (int)(sharedHealth * healthDistribution[i]);
                //TODO refactor this to be able to configure number of random spawned obstacles 
                spawnPlaces[i] = new SpawnPlace(_levelConfig.obstaclesSettings, 
                    _gameFactory, 
                    range,
                    spawnRange / 3,
                    healthForSpawnPlace);
            }
        }
        

        private void InitializeAndPlaceFloor()
        {
            GameObject floor = _gameFactory.CreateGameObject(Constants.Paths.MapPath);
            _levelConfig.plane = floor;
            _levelConfig.levelHeroSpawnPoint = floor.transform;
            _levelConfig.plane.transform.position = Vector3.zero;
        }

        private void InitializeAndPlaceWordFence()
        {
            List<GameObject> gates = new();
            for (int i = 0; i < _levelConfig.numberOfGates; i++)
            {
                var wordFence = _gameFactory.CreateGameObject(Constants.Paths.WordFencePath);
                gates.Add(wordFence);
            }

            gates[0].transform.position = new Vector3(gates[0].transform.position.x, gates[0].transform.position.y, 70);
            gates[1].transform.position = new Vector3(gates[1].transform.position.x, gates[1].transform.position.y, 35);
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
                    .CreateGameObjectAtPosition(Constants.Paths.HeroPath, _levelConfig.levelHeroSpawnPoint.position)
                    .GetComponent<Hero>();
            }
            else _hero.transform.position = _levelConfig.levelHeroSpawnPoint.position;

            _hero.Initialize(_signal);

            _signal.RegistryRaise(new GameSignals.OnHeroSpawned
            {
                Hero = _hero
            });
        }
    }
    
    public struct Range
    {
        public float from;
        public float to;
    }
}