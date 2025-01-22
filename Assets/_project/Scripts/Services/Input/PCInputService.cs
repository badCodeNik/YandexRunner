using _project.Scripts.Tools;
using UnityEngine;

namespace _project.Scripts.Services.Input
{
    public class PCInputService : MonoBehaviour
    {
        private Signal _signal;

        private void Start()
        {
            _signal = AllServices.Container.Single<Signal>();
        }

        private void Update()
        {
            if(UnityEngine.Input.GetKeyDown(KeyCode.A)) _signal.RegistryRaise(new OnSwipeLeft());
            if(UnityEngine.Input.GetKeyDown(KeyCode.D)) _signal.RegistryRaise(new OnSwipeRight());
            if(UnityEngine.Input.GetKeyDown(KeyCode.S)) _signal.RegistryRaise(new OnSwipeDown());
            if(UnityEngine.Input.GetKeyDown(KeyCode.W)) _signal.RegistryRaise(new OnSwipeUp());
        }
    }
}