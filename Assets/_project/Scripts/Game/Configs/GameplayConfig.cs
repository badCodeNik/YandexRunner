using _project.Scripts.Services;
using UnityEngine;

namespace _project.Scripts.Game.Configs
{
    [CreateAssetMenu(fileName = "GameplayConfig", menuName = "Configs/GameplayConfig")]
    public class GameplayConfig : Config
    {
        [SerializeField] private float scoreMultiplier;
        public float ScoreMultiplier => scoreMultiplier;
        
        public override void Initialize()
        {
            AllServices.Container.RegisterSingle(this);
        }
    }
}