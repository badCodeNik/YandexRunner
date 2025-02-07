using _project.Scripts.Services;
using UnityEngine;
using UnityEngine.Serialization;

namespace _project.Scripts.Game.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : Config
    {
        public Vector3 LevelHeroSpawnPoint;
        
        public GameObject plane;
        public GameObject finish;
        [Range(10,100)]
        public float levelLength;
        [Range(1,10)]
        public float levelWidth;

        public int numberOfObstacles;

        public override void Initialize()
        {
            AllServices.Container.RegisterSingle(this);
        }
    }
}