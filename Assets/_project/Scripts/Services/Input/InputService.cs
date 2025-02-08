using System;
using _project.Scripts.Tools;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils = _project.Scripts.Extentions.Utils;

namespace _project.Scripts.Services.Input
{
    public class InputService : IDisposable
{
    private readonly PlayerInput _input;
    private readonly Signal _signal;
    private readonly SwipeSettings _swipeSettings;

    private Vector2 _startPosition;
    private float _startTime;
    private Vector2 _endPosition;
    private float _endTime;

    public InputService()
    {
        _input = new PlayerInput();
        _swipeSettings = new SwipeSettings();
        _input.Player.PrimaryContact.started += StartTouchPrimary;
        _input.Player.PrimaryContact.canceled += EndTouchPrimary;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        _startPosition = position;
        _startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        _endPosition = position;
        _endTime = time;
        //DetectSwipe();
    }
    //
    // private void DetectSwipe()
    // {
    //     
    //     if (!(Vector3.Distance(_startPosition, _endPosition) >= _swipeSettings.swipeThreshold) ||
    //         !(_endTime - _startTime <= _swipeSettings.maxTime)) return;
    //
    //     var swipeDirection = _endPosition - _startPosition;
    //     var angle = Mathf.Atan2(swipeDirection.y, swipeDirection.x) * Mathf.Rad2Deg;
    //
    //     if (angle < 0)
    //         angle += 360;
    //
    //     if (angle >= 45 && angle < 135)
    //         // SwipeUp
    //     else if (angle >= 135 && angle < 225)
    //         //Swipe left
    //         else if (angle >= 225 && angle < 315)
    //         //Swipe down
    //     else
    //         //SwipeRight
    //         
    //     Handheld.Vibrate();
    // }

    public void EnableInput() => _input.Enable();
    public void DisableInput() => _input.Disable();

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

    public class SwipeSettings
    {
        public float maxTime;
        public float swipeThreshold;
    }
    
}