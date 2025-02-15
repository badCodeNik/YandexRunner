using UnityEngine;

namespace _project.Scripts.Game.Obstacles
{
    public abstract class Obstacle : MonoBehaviour
    {
        [SerializeField] private ObstacleSpawnPosition obstacleSpawnPosition;
        [SerializeField] private float health;
        public abstract string ObstaclePath { get; }

        public ObstacleSpawnPosition ObstacleSpawnPosition => obstacleSpawnPosition;
        public float Health => health;

        public abstract void Activate();

        private void SetHealth(float health)
        {
            this.health = health;
        }
        
        public void TakeDamage(float damage)
        {
            SetHealth(Health - damage);

            if (Health <= 0)
            {
                Debug.Log($"{gameObject.name} was destroyed!");
            }
        }
    }
}