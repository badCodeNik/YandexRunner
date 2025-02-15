using System;
using System.Collections.Generic;
using _project.Scripts.Game.Configs;
using _project.Scripts.Game.Entities;
using _project.Scripts.Game.GameRoot;
using _project.Scripts.Game.Obstacles;
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
            ActivateTapPanel();
            InitializeLevel();
            SpawnHero();
        }

        private void InitializeLevel()
        {
            InitializeAndPlaceFloor();
            InitializeAndPlaceWordFence();
            InitializeAndPlaceObstacles();
        }

        private void InitializeAndPlaceFloor()
        {
            GameObject floor = _gameFactory.CreateGameObject(Constants.Paths.MapPath);
            _levelConfig.plane = floor;
            _levelConfig.LevelHeroSpawnPoint = floor.transform;
            _levelConfig.plane.transform.position = Vector3.zero;
        }

        private void InitializeAndPlaceObstacles()
        {
            int[] positionsToSpawn = { 60, 80, 19, 10, 20, 27 };
            for (var index = 0; index < _levelConfig.obstaclesSettings.obstaclesToSpawn.Count; index++)
            {
                var obstacle = _levelConfig.obstaclesSettings.obstaclesToSpawn[index];
                Vector3 positionToSpawn;
                switch (obstacle.ObstacleSpawnPosition)
                {
                    case ObstacleSpawnPosition.Left:
                        positionToSpawn = new Vector3(-2, 0, positionsToSpawn[index]);
                        break;
                    case ObstacleSpawnPosition.Right:
                        positionToSpawn = new Vector3(2, 0, positionsToSpawn[index]);
                        break;
                    case ObstacleSpawnPosition.Middle:
                        positionToSpawn = new Vector3(0, 0, positionsToSpawn[index]);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _gameFactory.CreateGameObjectAtPosition(obstacle.ObstaclePath, positionToSpawn);
            }
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