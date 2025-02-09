using System;
using _project.Scripts.Services.Services;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Components
{
    [Serializable]
    public class MoveComponent
    {
        private readonly Transform _heroRoot;
        private readonly AnimationHandler _animationHandler;
        [SerializeField] private float forwardSpeed = 5f;
        [SerializeField] private float lateralSpeed = 2f;
        [SerializeField] private float topSpeed;
        [SerializeField] private float minSpeed;


        private float _desiredX;

        public bool IsMoving { get; private set; }

        public MoveComponent(Transform heroRoot, AnimationHandler animationHandler)
        {
            _heroRoot = heroRoot;
            _animationHandler = animationHandler;
        }

        public void Move(float axis)
        {
            IsMoving = true;
            _heroRoot.position += new Vector3(axis * lateralSpeed, 0, forwardSpeed * Time.deltaTime);
            var positionX = _heroRoot.position.x;
            var limitedPos = Math.Clamp(positionX, -2, 2);
            _heroRoot.position = new Vector3(limitedPos, _heroRoot.position.y, _heroRoot.position.z);
            ScoreService.CountScore(forwardSpeed * Time.deltaTime);

            if (forwardSpeed < 5) _animationHandler.PlayWalk();
            else _animationHandler.PlayRun();

        }

        public void Stop()
        {
            IsMoving = false;
        }

        public void SetSpeed(float newForwardSpeed)
        {
            forwardSpeed = newForwardSpeed;
        }
    }
}