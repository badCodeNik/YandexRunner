using System;
using UnityEngine;

namespace _project.Scripts.Game.Obstacles
{
    public class ObstacleActivator : MonoBehaviour
    {
        [SerializeField] private Obstacle obstacle;
        
        private void OnTriggerEnter(Collider other)
        {
            obstacle.Activate();
        }
    }
}