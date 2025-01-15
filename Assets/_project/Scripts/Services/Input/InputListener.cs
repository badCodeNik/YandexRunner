using _project.Scripts.Extentions;
using _project.Scripts.Game.GameplayControllers;
using _project.Scripts.Tools;
using UnityEngine;
using Zenject;

namespace _project.Scripts.Services.Input
{
    public class InputListener
    {
        private HeroMoveController _heroMoveController;
        private readonly Signal _signal;

        public InputListener(HeroMoveController heroMoveController, Signal signal)
        {
            _heroMoveController = heroMoveController;
            _signal = signal;
            _signal.Subscribe<OnSwipeDown>(OnSignal);
            _signal.Subscribe<OnSwipeUp>(OnSignal);
            _signal.Subscribe<OnSwipeLeft>(OnSignal);
            _signal.Subscribe<OnSwipeRight>(OnSignal);
        }

        private void OnSignal(OnSwipeLeft data)
        {
            _heroMoveController.SwipeLeft();
        }

        private void OnSignal(OnSwipeRight data)
        {
            _heroMoveController.SwipeRight();
        }

        private void OnSignal(OnSwipeUp data)
        {
            _heroMoveController.SwipeUp();
        }

        private void OnSignal(OnSwipeDown data)
        {
            _heroMoveController.SwipeDown();
        }
    }
}