using _project.Scripts.Services;
using UnityEngine;

namespace _project.Scripts.Game.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : Config
    {
        [SerializeField] private Transform levelHeroSpawnPoint;
        [SerializeField] private GameObject plane;

        public Transform LevelHeroSpawnPoint => levelHeroSpawnPoint;
        public GameObject Plane => plane;

        public override void Initialize()
        {
            AllServices.Container.RegisterSingle(this);

        }
    }
}