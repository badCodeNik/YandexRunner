using UnityEngine;

namespace _project.Scripts.Game.Obstacles
{
    public abstract class Obstacle : MonoBehaviour
    {
        [SerializeField] private ObstacleSpawnPosition obstacleSpawnPosition;
        public abstract string ObstaclePath { get; }

        public ObstacleSpawnPosition ObstacleSpawnPosition => obstacleSpawnPosition;

        public abstract void Activate();
    }
}