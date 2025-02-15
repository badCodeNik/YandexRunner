using System;
using System.Collections.Generic;
using _project.Scripts.Game.Obstacles;
using _project.Scripts.Services;
using UnityEngine;

namespace _project.Scripts.Game.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : Config
    {
        public Transform LevelHeroSpawnPoint;
        
        public GameObject plane;
        public GameObject finish;
        public ObstaclesSettings obstaclesSettings;

        
        public int numberOfGates;

        public override void Initialize()
        {
            AllServices.Container.RegisterSingle(this);
            obstaclesSettings = new ObstaclesSettings();
        }
    }

    [Serializable]
    public class ObstaclesSettings
    {
        [Range(10, 100)] 
        public int obstaclesHealth;
        public List<Obstacle> obstaclesToSpawn;
        public float distanceBeforeFinish;
        public float distanceAfterStart;
    }
}