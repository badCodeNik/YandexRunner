using System;
using _project.Scripts.Game.Entities.Components;
using _project.Scripts.Tools;
using UnityEngine;

namespace _project.Scripts.Game.Entities
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class Hero : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject groundCheck;
        [SerializeField] private MoveComponent moveComponent;
        [SerializeField] private JumpComponent jumpComponent;
        private CollisionHandler _collisionHandler;
        private AnimationHandler _animationHandler;

        public MoveComponent MoveComponent => moveComponent;
        public JumpComponent JumpComponent => jumpComponent;
        public bool IsInitialized { get; private set; }

        public void Initialize(Signal signal)
        {
            if (IsInitialized) return;

            _collisionHandler = new CollisionHandler(signal);
            _animationHandler = new AnimationHandler(animator);
            moveComponent = new MoveComponent(transform, _animationHandler);
            jumpComponent = new JumpComponent(GetComponent<Rigidbody>(), groundCheck);
            IsInitialized = true;
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