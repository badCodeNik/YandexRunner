using UnityEngine;

namespace _project.Scripts.Game.Obstacles
{
    public abstract class Obstacle : MonoBehaviour
    {
        public abstract string ObstaclePath { get; }
        public abstract ObstacleSpawnPosition ObstacleSpawnPosition { get; }

        public abstract void Activate();
    }
}