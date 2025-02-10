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
            InitializeLevel();
            SpawnHero();
            ActivateTapPanel();
        }

        private void InitializeLevel()
        {
            GameObject floor = _gameFactory.CreateGameObject(Constants.Paths.FloorPath);
            GameObject finish = _gameFactory.CreateGameObject(Constants.Paths.FinishPath);
            InitializeAndPlaceWordFence();
            InitializeAndPlaceObstacles();
            _levelConfig.plane = floor;
            _levelConfig.finish = finish;
            _levelConfig.plane.transform.position = Vector3.zero;

            Mesh planeMesh = CreatePlaneMesh(_levelConfig.levelWidth, _levelConfig.levelLength);
            var meshFilter = _levelConfig.plane.GetComponent<MeshFilter>();
            if (meshFilter != null)
            {
                meshFilter.mesh = planeMesh;
            }

            var collider = _levelConfig.plane.GetComponent<MeshCollider>();
            if (collider == null)
            {
                collider = _levelConfig.plane.AddComponent<MeshCollider>();
            }

            collider.sharedMesh = planeMesh;


            Vector3 planeSize = planeMesh.bounds.size;
            float planeLength = planeSize.z;
            float startZ = _levelConfig.plane.transform.position.z - planeLength / 2 + 2;
            _levelConfig.LevelHeroSpawnPoint = new Vector3(0, _levelConfig.plane.transform.position.y + 0.5f, startZ);
            _levelConfig.finish.transform.position = new Vector3(
                0,
                _levelConfig.plane.transform.position.y + 0.5f,
                _levelConfig.plane.transform.position.z + planeLength / 2);
        }

        private void InitializeAndPlaceObstacles()
        {
            Vector3 positionToSpawn;
            float previousZ = 0;
            foreach (var obstacle in _levelConfig.obstaclesToSpawn)
            {
                switch (obstacle.ObstacleSpawnPosition)
                {
                    case ObstacleSpawnPosition.Left:
                        positionToSpawn = new Vector3(-2, 0, previousZ + 10);
                        break;
                    case ObstacleSpawnPosition.Right:
                        positionToSpawn = new Vector3(2, 0, previousZ + 10);
                        break;
                    case ObstacleSpawnPosition.Middle:
                        positionToSpawn = new Vector3(0, 0, previousZ + 10);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                previousZ += 10;
                _gameFactory.CreateGameObjectAtPosition(obstacle.ObstaclePath, positionToSpawn);
            }
        }

        private Mesh CreatePlaneMesh(float levelConfigLevelWidth, float levelConfigLevelLength)
        {
            Mesh mesh = new Mesh();

            Vector3[] vertices =
            {
                new(-levelConfigLevelWidth / 2, 0, -levelConfigLevelLength / 2),
                new(levelConfigLevelWidth / 2, 0, -levelConfigLevelLength / 2),
                new(-levelConfigLevelWidth / 2, 0, levelConfigLevelLength / 2),
                new(levelConfigLevelWidth / 2, 0, levelConfigLevelLength / 2)
            };

            int[] triangles = new int[6] { 0, 2, 1, 2, 3, 1 };

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();

            return mesh;
        }

        private void InitializeAndPlaceWordFence()
        {
            List<GameObject> gates = new();
            for (int i = 0; i < _levelConfig.numberOfGates; i++)
            {
                var wordFence = _gameFactory.CreateGameObject(Constants.Paths.WordFencePath);
                gates.Add(wordFence);
            }

            gates[0].transform.position =
                new Vector3(gates[0].transform.position.x, gates[0].transform.position.y, -15);
            gates[1].transform.position = new Vector3(gates[0].transform.position.x, gates[0].transform.position.y, 35);
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