using System.Collections;
using UnityEngine;

namespace _project.Scripts.Game.Obstacles
{
    public class Desk : Obstacle
    {
        [SerializeField] private float _desiredLeftX = 3;
        [SerializeField] private float _desiredRightX = -3;
        public override string ObstaclePath => Constants.Paths.DeskPath;
        public override ObstacleSpawnPosition ObstacleSpawnPosition { get; }
        private readonly float _shiftingSpeed = 10;
        private Vector3 _desiredPosition;

        public override void Activate()
        {
            StartCoroutine(MoveDesk());
        }

        private IEnumerator MoveDesk()
        {
            while (true)
            {
                _desiredPosition = new Vector3(_desiredRightX, transform.position.y, transform.position.z);
                yield return MoveToPosition(_desiredPosition);
                yield return new WaitForSeconds(0.5f);
                _desiredPosition = new Vector3(_desiredLeftX, transform.position.y, transform.position.z);
                yield return MoveToPosition(_desiredPosition);
                yield return new WaitForSeconds(0.5f);
            }
        }

        private IEnumerator MoveToPosition(Vector3 targetPosition)
        {
            while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, _shiftingSpeed * Time.deltaTime);
                yield return null;
            }

            transform.position = targetPosition;
        }
    }
}