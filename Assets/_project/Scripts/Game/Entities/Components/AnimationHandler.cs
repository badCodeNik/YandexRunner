using System;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Components
{
    [Serializable]
    public class AnimationHandler
    {
        public AnimationHandler(Animator animator)
        {
            this.animator = animator;
        }

        [SerializeField] private Animator animator;
        private readonly int _isRunningHash = Animator.StringToHash("isRunning");
        private readonly int _isWalkingHash = Animator.StringToHash("isWalking");

        public void PlayRun()
        {
            animator.SetBool(_isRunningHash, true);
            animator.SetBool(_isWalkingHash, false);
        }

        public void PlayWalk()
        {
            animator.SetBool(_isWalkingHash, true);
            animator.SetBool(_isRunningHash, false);
        }
    }
}