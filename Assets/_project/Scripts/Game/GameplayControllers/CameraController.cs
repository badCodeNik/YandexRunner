using _project.Scripts.Tools;
using UnityEngine;

namespace _project.Scripts.Game.GameplayControllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        private const float Smoothing = 5f;
        private readonly Vector3 offset = new(0,6,-8);

        public void Initialize(Signal signal)
        {
            signal.Subscribe<GameSignals.OnHeroSpawned>(OnSignal);
        }
        private void LateUpdate()
        {
            if (!target) return;
        
            var desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Smoothing * Time.deltaTime);
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
