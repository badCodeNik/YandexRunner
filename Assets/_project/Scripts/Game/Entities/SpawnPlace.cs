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
        [SerializeField] private float _sharedHealth;


        public SpawnPlace(ObstaclesSettings obstaclesSettings, GameFactory gameFactory, Range range, int obstaclesToSpawnCount)
        {
            _obstaclesSettings = obstaclesSettings;
            _gameFactory = gameFactory;
            _range = range;
            _obstaclesToSpawnCount = obstaclesToSpawnCount;
            Debug.Log(obstaclesToSpawnCount);
            CreateObstacles();
        }

        public void SetSharedHealth(float health)
        {
            _sharedHealth = health;
        }

        private void CreateObstacles()
        {
            //TODO make up a formula for sharing health among obstacles
            for (var index = 0; index < _obstaclesToSpawnCount; index++)
            {
                var obstacle = _obstaclesSettings.obstaclesToSpawn[Random.Range(0, _obstaclesSettings.obstaclesToSpawn.Length)];

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