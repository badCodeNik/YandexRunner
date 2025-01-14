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

        public void Collide(Collider other)
        {
            if(other.CompareTag("Finish")) _signal.RegistryRaise(new GameSignals.OnGameEnded { hasWon = true });
        }
    }
}