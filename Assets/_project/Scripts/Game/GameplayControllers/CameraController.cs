using _project.Scripts.Extentions;
using _project.Scripts.Game.Infrastructure;
using UnityEngine;

namespace _project.Scripts.Game.GameplayControllers
{
    public class CameraController : SignalListener<GameSignals.OnHeroSpawned>
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset; 
        [SerializeField] private float smoothing = 5f;

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

        protected override void OnSignal(GameSignals.OnHeroSpawned data)
        {
            SetTarget(data.Hero.transform);
        }
    }
}
