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

        private enum MovementState
        {
            None,
            Left,
            Right,
            Center
        }

        private MovementState _currentState = MovementState.None;
        private float _desiredX;

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

            if (_currentState == MovementState.None) return;

            UpdateLateralMovement();
        }

        private void UpdateLateralMovement()
        {
            float direction = 0;

            switch (_currentState)
            {
                case MovementState.Left:
                    _desiredX = -4;
                    direction = -1;
                    break;

                case MovementState.Right:
                    _desiredX = 4;
                    direction = 1;
                    break;

                case MovementState.Center:
                    _desiredX = 0;
                    direction = Mathf.Sign(_desiredX - _heroRoot.position.x);
                    break;
            }

            _heroRoot.position += new Vector3(direction, 0, 0) * lateralSpeed * Time.deltaTime;

            if (Mathf.Abs(_heroRoot.position.x - _desiredX) < 0.1f)
            {
                StopShifting();
                _heroRoot.position = new Vector3(_desiredX, _heroRoot.position.y, _heroRoot.position.z);
            }
        }

        public void MoveToLeft()
        {
            _currentState = MovementState.Left;
        }

        public void MoveToRight()
        {
            _currentState = MovementState.Right;
        }

        public void MoveToCenter()
        {
            _currentState = MovementState.Center;
        }

        private void StopShifting()
        {
            _currentState = MovementState.None;
        }

        public void SetSpeed(float newForwardSpeed)
        {
            forwardSpeed = newForwardSpeed;
        }
    }
}