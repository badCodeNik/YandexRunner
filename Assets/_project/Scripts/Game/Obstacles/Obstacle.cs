using TMPro;
using UnityEngine;

namespace _project.Scripts.Game.Obstacles
{
    public abstract class Obstacle : MonoBehaviour
    {
        [SerializeField] private float _health;
        [SerializeField] private TMP_Text _healthText;
        public abstract string ObstaclePath { get; }

        public float Health => _health;

        public abstract void Activate();

        public void SetHealth(float health)
        {
            _health = health;
            _healthText.text = health.ToString();
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