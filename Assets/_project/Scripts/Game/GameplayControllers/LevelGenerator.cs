using _project.Scripts.Game.Entities;
using _project.Scripts.Tools;
using UnityEngine;

namespace _project.Scripts.Game.GameplayControllers
{
    public class LevelGenerator : MonoBehaviour
    {
        private Hero _hero;
        private Signal _signal;

        public LevelGenerator(Signal signal)
        {
            _signal = signal;
            _signal.Subscribe<GameSignals.OnHeroSpawned>(OnSignal);
        }

        private void OnSignal(GameSignals.OnHeroSpawned data)
        {
            _hero = data.Hero;
        }
        
        
        
    }
}