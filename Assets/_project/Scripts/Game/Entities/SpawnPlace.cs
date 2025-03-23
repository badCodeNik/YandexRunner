using System;
using System.Collections.Generic;
using _project.Scripts.Game.Configs;
using _project.Scripts.Services;
using UnityEngine;
using Random = UnityEngine.Random;
using Range = _project.Scripts.Game.Infrastructure.Range;

namespace _project.Scripts.Game.Entities
{
    [Serializable]
    public class SpawnPlace
    {
        private readonly ObstaclesSettings _obstaclesSettings;
        private readonly GameFactory _gameFactory;
        private readonly Range _range;
        private readonly int _obstaclesToSpawnCount;
        private int _sharedHealth;


        public SpawnPlace(ObstaclesSettings obstaclesSettings, GameFactory gameFactory, Range range,
            int obstaclesToSpawnCount, int healthForSpawnPlace)
        {
            _obstaclesSettings = obstaclesSettings;
            _gameFactory = gameFactory;
            _range = range;
            _obstaclesToSpawnCount = obstaclesToSpawnCount;
            _sharedHealth = healthForSpawnPlace;
            CreateObstacles();
        }

        public void SetSharedHealth(int health)
        {
            _sharedHealth = health;
        }

        private void CreateObstacles()
        {
            float minHealthPercentage = 0.2f;
            int minHealthPerObstacle = (int)(_sharedHealth * minHealthPercentage);
            int obstacleCount = _obstaclesToSpawnCount;
            int[] obstacleHealths = new int[obstacleCount];

            for (int i = 0; i < obstacleCount; i++)
            {
                obstacleHealths[i] = minHealthPerObstacle;
            }

            int remainingHealth = _sharedHealth - (minHealthPerObstacle * obstacleCount);
            for (int i = 0; i < remainingHealth; i++)
            {
                int randomIndex = Random.Range(0, obstacleCount);
                obstacleHealths[randomIndex]++;
            }
            for (var index = 0; index < obstacleCount; index++)
            {
                var obstacle =
                    _obstaclesSettings.obstaclesToSpawn[Random.Range(0, _obstaclesSettings.obstaclesToSpawn.Length)];
                obstacle.SetHealth(obstacleHealths[index]);
                Debug.Log(obstacleHealths[index]);
                float randomZ = Random.Range(_range.from, _range.to);

                var spawnPosition = Random.Range(0, 3);
                var positionToSpawn = spawnPosition switch
                {
                    (int)ObstacleSpawnPosition.Left => new Vector3(-2, 0, randomZ),
                    (int)ObstacleSpawnPosition.Right => new Vector3(2, 0, randomZ),
                    (int)ObstacleSpawnPosition.Middle => new Vector3(0, 0, randomZ),
                    _ => throw new ArgumentOutOfRangeException()
                };

                _gameFactory.CreateGameObjectAtPosition(obstacle.ObstaclePath, positionToSpawn);
            }
        }
    }
}