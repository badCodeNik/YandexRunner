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
        [SerializeField] private float lateralSpeed = 15f;
        [SerializeField] private float topSpeed;
        [SerializeField] private float minSpeed;
        private bool _isMovingLeft;
        private bool _isMovingRight;
        private const float ShiftDistance = 3.8f;
        private float _movedDistance;
        private Vector3 _initialPosition;
        private bool _isShifting = false;

        public bool IsMoving { get; private set; }

        public MoveComponent(Transform heroRoot, AnimationHandler animationHandler)
        {
            _heroRoot = heroRoot;
            _animationHandler = animationHandler;
        }

        public void Move()
        {
            IsMoving = true;
            _heroRoot.position += Vector3.forward * forwardSpeed * Time.deltaTime;
            ScoreService.CountScore(forwardSpeed * Time.deltaTime);
            if (forwardSpeed < 5) _animationHandler.PlayWalk();
            else _animationHandler.PlayRun();

            if (!_isShifting) return;

            if (_isMovingLeft)
            {
                _heroRoot.position += Vector3.left * lateralSpeed * Time.deltaTime;
                _movedDistance += lateralSpeed * Time.deltaTime;

                if (_movedDistance >= ShiftDistance)
                {
                    StopShifting();
                }
            }
            else if (_isMovingRight)
            {
                _heroRoot.position += Vector3.right * lateralSpeed * Time.deltaTime;
                _movedDistance += lateralSpeed * Time.deltaTime;

                if (_movedDistance >= ShiftDistance)
                {
                    StopShifting();
                }
            }
        }

        public void MoveLeft()
        {
            _initialPosition = _heroRoot.position;
            _isMovingLeft = true;
            _isMovingRight = false;
            _isShifting = true;
            _movedDistance = 0f;
        }

        public void MoveRight()
        {
            _initialPosition = _heroRoot.position;
            _isMovingRight = true;
            _isMovingLeft = false;
            _isShifting = true;
            _movedDistance = 0f;
        }

        private void StopShifting()
        {
            _isShifting = false;
            _isMovingLeft = false;
            _isMovingRight = false;
        }

        public void SetSpeed(float newForwardSpeed)
        {
            forwardSpeed = newForwardSpeed;
        }
    }
}