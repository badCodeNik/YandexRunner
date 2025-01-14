using System;
using _project.Scripts.Extentions;
using _project.Scripts.Game.Entities;

namespace _project.Scripts.Game.GameplayControllers
{
    public class LevelGenerator : SignalListener<GameSignals.OnHeroSpawned>
    {
        private Hero _hero;
        protected override void OnSignal(GameSignals.OnHeroSpawned data)
        {
            _hero = data.Hero;
        }

        private void Update()
        {
            // нам нужно генерировать уровень в зависимости локации персонажа. Удалять позади и добавлять впереди
            //можно сделать префабы и генерить их спереди и удалять сзади
        }
    }
}