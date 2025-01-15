using _project.Scripts.Tools;
using UnityEngine;
using Zenject;

namespace _project.Scripts.Game.GameplayControllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset; 
        [SerializeField] private float smoothing = 5f;

        [Inject]
        public void Construct(Signal signal)
        {
            signal.Subscribe<GameSignals.OnHeroSpawned>(OnSignal);
        }
        private void LateUpdate()
        {
            if (!target) return;
        
            var desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothing * Time.deltaTime);
        }

        private void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }

        private void OnSignal(GameSignals.OnHeroSpawned data)
        {
            SetTarget(data.Hero.transform);
        }
    }
}
