using _project.Scripts.Extentions;
using _project.Scripts.Game.GameplayControllers;
using UnityEngine;

namespace _project.Scripts.Services.Input
{
    public class InputListener : SignalListener<OnSwipeLeft, OnSwipeRight, OnSwipeUp, OnSwipeDown>
    {
        [SerializeField] private HeroMoveController heroMoveController;
        protected override void OnSignal(OnSwipeLeft data)
        {
            heroMoveController.SwipeLeft();
        }

        protected override void OnSignal(OnSwipeRight data)
        {
            heroMoveController.SwipeRight();
        }

        protected override void OnSignal(OnSwipeUp data)
        {
            heroMoveController.SwipeUp();
        }

        protected override void OnSignal(OnSwipeDown data)
        {
            heroMoveController.SwipeDown();

        }
    }
}