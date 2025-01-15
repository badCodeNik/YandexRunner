using System;
using _project.Scripts.Extentions;
using _project.Scripts.Game.Entities;
using _project.Scripts.Tools;
using Zenject;

namespace _project.Scripts.Game.GameplayControllers
{
    public class LevelGenerator : ITickable
    {
        private Hero _hero;
        private Signal _signal;


        [Inject]
        public void Construct(Signal signal)
        {
            _signal = signal;
            _signal.Subscribe<GameSignals.OnHeroSpawned>(OnSignal);
        }
        private void OnSignal(GameSignals.OnHeroSpawned data)
        {
            _hero = data.Hero;
        }
        
        public void Tick()
        {
            
            // нам нужно генерировать уровень в зависимости локации персонажа. Удалять позади и добавлять впереди
            //можно сделать префабы и генерить их спереди и удалять сзади   
        }
    }
}