using UnityEngine;

namespace _project.Scripts.Game.Obstacles
{
    [RequireComponent(typeof(Collider))]
    public abstract class Obstacle : MonoBehaviour
    {
        public abstract ObstacleSpawnPosition ObstacleSpawnPosition { get;  }
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("On trigger enter");
            Activate();
        }

        protected abstract void Activate();
    }
}