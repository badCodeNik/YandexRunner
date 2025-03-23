using System;
using _project.Scripts.Game.Obstacles;
using _project.Scripts.Services;
using UnityEngine;

namespace _project.Scripts.Game.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : Config
    {
        public Transform levelHeroSpawnPoint;
        public GameObject plane;
        public GameObject finish;
        public ObstaclesSettings obstaclesSettings;
        public int boostersPerLevel;
        public int moneyPerLevel;
        
        public int numberOfGates;

        public override void Initialize()
        {
            AllServices.Container.RegisterSingle(this);
        }
    }

    [Serializable]
    public class ObstaclesSettings
    {
        [Range(10, 100)] public int obstaclesHealth;
        public Obstacle[] obstaclesToSpawn;
        public float distanceBetweenObstacles;
        public int minObstaclesToSpawnCount;
        public int maxObstaclesToSpawnCount;
        public float moneyPerObstacle;
    }
}