using _project.Scripts.Extentions;
using _project.Scripts.Game.Entities;
using _project.Scripts.Game.Infrastructure;
using _project.Scripts.Services.Input;

namespace _project.Scripts.Game.GameplayControllers
{
    public class HeroMoveController : SignalListener<
        GameSignals.OnGameStarted,
        GameSignals.OnGameEnded,
        GameSignals.OnHeroSpawned>
    {
        private Hero _hero;
        private bool _isMoving;
        private Position _position = Position.Middle;
        

        protected override void OnSignal(GameSignals.OnGameStarted data)
        {
            ServiceLocator.Instance.GetInstance<InputService>().EnableInput();
            _isMoving = true;
        }

        protected override void OnSignal(GameSignals.OnGameEnded data) => _isMoving = false;

        protected override void OnSignal(GameSignals.OnHeroSpawned data) => _hero = data.Hero;

        public void SwipeLeft()
        {
            if (_position == Position.Left) return;
            _hero.MoveComponent.MoveLeft();
            _position--;
        }

        public void SwipeRight()
        {
            if (_position == Position.Right) return;
            _hero.MoveComponent.MoveRight();
            _position++;
        }

        private void Update()
        {
            if(_hero == null) return;
            if (!_hero.IsInitialized) return;
            if (_isMoving) _hero.MoveComponent.Move();
            _hero.JumpComponent.Update();
        }

        public void SwipeUp()
        {
            _hero.JumpComponent.Jump();
        }

        public void SwipeDown()
        {
            
        }
    }

    public enum Position
    {
        Left = 1,
        Middle = 2,
        Right = 3
    }
}