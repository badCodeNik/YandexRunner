using System;
using _project.Scripts.Game.Infrastructure;
using _project.Scripts.Tools;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils = _project.Scripts.Extentions.Utils;

namespace _project.Scripts.Services.Input
{
    public class InputService : IDisposable
    {
        private readonly PlayerInput _input;
        private const float SwipeThreshold = .1f;
        private const float MaxTime = 1f;
        private Vector2 _startPosition;
        private float _startTime;
        private Vector2 _endPosition;
        private float _endTime;
        private readonly Signal _signal;

        private void SwipeStart(Vector2 position, float time)
        {
            _startPosition = position;
            _startTime = time;
        }

        private void SwipeEnd(Vector2 position, float time)
        {
            _endPosition = position;
            _endTime = time;
            DetectSwipe();
        }

        private void DetectSwipe()
        {
            if (!(Vector3.Distance(_startPosition, _endPosition) >= SwipeThreshold) ||
                !(_endTime - _startTime <= MaxTime)) return;

            var swipeDirection = _endPosition - _startPosition;
            var xDirection = Mathf.Abs(swipeDirection.x);
            var yDirection = Mathf.Abs(swipeDirection.y);

            if (xDirection > yDirection)
                if (swipeDirection.x > 0) _signal.RegistryRaise(new OnSwipeRight());
                else _signal.RegistryRaise(new OnSwipeLeft());
            else if (yDirection > xDirection)
                if (swipeDirection.y > 0) _signal.RegistryRaise(new OnSwipeUp());
                else _signal.RegistryRaise(new OnSwipeDown());
        }


        public InputService(Signal signal)
        {
            _signal = signal;
            _input = new PlayerInput();
            _input.Player.PrimaryContact.started += StartTouchPrimary;
            _input.Player.PrimaryContact.canceled += EndTouchPrimary;
            Debug.Log(Camera.main);
        }

        public void EnableInput()
        {
            _input.Enable();
        }

        public void DisableInput()
        {
            _input.Disable();
        }

        private void StartTouchPrimary(InputAction.CallbackContext context) =>
            SwipeStart(Utils.ScreenToWorldPoint(Camera.main, _input.Player.PrimaryPosition.ReadValue<Vector2>()),
                (float)context.time);

        private void EndTouchPrimary(InputAction.CallbackContext context) =>
            SwipeEnd(Utils.ScreenToWorldPoint(Camera.main, _input.Player.PrimaryPosition.ReadValue<Vector2>()),
                (float)context.time);


        public void Dispose()
        {
            _input.Disable();
            _input.Player.PrimaryContact.started -= StartTouchPrimary;
            _input.Player.PrimaryContact.canceled -= EndTouchPrimary;
        }
    }

    public struct OnSwipeLeft
    {
    }

    public struct OnSwipeRight
    {
    }

    public struct OnSwipeUp
    {
    }

    public struct OnSwipeDown
    {
    }
}