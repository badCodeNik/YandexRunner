using UnityEngine;
using UnityEngine.Serialization;

namespace _project.Scripts.Game.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "LevelConfig", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private Transform levelHeroSpawnPoint;
        [SerializeField] private Transform levelMonsterSpawnPoint;
        //[SerializeField] private int gateNumber;
        [SerializeField] private GameObject plane;

        public Transform LevelHeroSpawnPoint => levelHeroSpawnPoint;
        public Transform LevelMonsterSpawnPoint => levelMonsterSpawnPoint;

        public GameObject Plane => plane;

        //public int GateNumber => gateNumber;
    }
}