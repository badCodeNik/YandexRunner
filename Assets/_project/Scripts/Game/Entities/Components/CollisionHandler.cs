using _project.Scripts.Game.Obstacles;
using _project.Scripts.Tools;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Components
{
    public class CollisionHandler
    {
        private readonly Signal _signal;

        public CollisionHandler(Signal signal)
        {
            _signal = signal;
        }

        public void Trigger(Collider other)
        {
            if (other.CompareTag("Finish")) _signal.RegistryRaise(new GameSignals.OnGameEnded { HasWon = true });
            
            //TODO : нужно пофиксить коллайдер и переставить скрипт на дочерний объект
        }

        public void Collide(Collision other)
        {
            var obstacle = other.collider.GetComponentInParent(typeof(Obstacle));
            
            if (obstacle != null) _signal.RegistryRaise(new GameSignals.OnGameEnded { HasWon = false });
        }
    }
}