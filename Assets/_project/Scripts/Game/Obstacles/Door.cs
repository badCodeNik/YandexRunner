using System.Collections;
using UnityEngine;

namespace _project.Scripts.Game.Obstacles
{
    public class Door : Obstacle
    {
        [SerializeField] private GameObject door;
        [SerializeField] private float rotationSpeed = 150f;
        [SerializeField] private float targetAngle = -45f;

        protected override void Activate()
        {
            StartCoroutine(OpenDoor());
        }

        private IEnumerator OpenDoor()
        {
            var startRotation = door.transform.rotation;
            var targetRotation = Quaternion.Euler(startRotation.eulerAngles.x, targetAngle, startRotation.eulerAngles.z);

            var elapsedTime = 0f;
            var duration = Mathf.Abs(targetAngle - startRotation.eulerAngles.y) / rotationSpeed;

            while (elapsedTime < duration)
            {
                door.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            door.transform.rotation = targetRotation;
        }
    }
}