using UnityEngine;

namespace _project.Scripts.Game.Obstacles
{
    public abstract class Obstacle : MonoBehaviour
    {
        public abstract ObstacleSpawnPosition ObstacleSpawnPosition { get;  }

        public abstract void Activate();
    }
}