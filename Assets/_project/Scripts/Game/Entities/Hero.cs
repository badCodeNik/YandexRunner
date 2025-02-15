using _project.Scripts.Game.Entities.Components;
using _project.Scripts.Tools;
using UnityEngine;

namespace _project.Scripts.Game.Entities
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class Hero : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private MoveComponent moveComponent;
        private CollisionHandler _collisionHandler;
        private AnimationHandler _animationHandler;

        public MoveComponent MoveComponent => moveComponent;
        public bool IsInitialized { get; private set; }

        public void Initialize(Signal signal)
        {
            if (IsInitialized) return;

            _collisionHandler = new CollisionHandler(signal);
            _animationHandler = new AnimationHandler(animator);
            moveComponent = new MoveComponent(transform, _animationHandler);
            IsInitialized = true;
            signal.Subscribe<GameSignals.OnGameEnded>(OnSignal);
        }

        private void OnSignal(GameSignals.OnGameEnded data)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            if (data.HasWon) _animationHandler.PlayWin();
            _animationHandler.PlayLost();
        }

        private void OnTriggerEnter(Collider other)
        {
            _collisionHandler.Trigger(other);
        }

        private void OnCollisionEnter(Collision other)
        {
            _collisionHandler.Collide(other);
        }
    }
}