using UnityEngine;

namespace _project.Scripts.Services.Services
{
    public static class AppConfigurator
    {
        public static void Configure()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}