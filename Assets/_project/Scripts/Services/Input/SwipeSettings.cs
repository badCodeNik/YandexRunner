using System;

namespace _project.Scripts.Services.Input
{
    [Serializable]
    public class SwipeSettings
    {
        public float swipeThreshold = 0.1f;
        public float maxTime = 1f;
        public float deadZone = 5f;
    }
}