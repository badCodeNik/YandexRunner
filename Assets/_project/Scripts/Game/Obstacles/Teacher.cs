using System;
using _project.Scripts.Game.Entities;
using UnityEngine;

namespace _project.Scripts.Game.Obstacles
{
    public class Teacher : Obstacle
    {
        [SerializeField] private Animator animator;
        [SerializeField] private float speed;
        public override ObstacleSpawnPosition ObstacleSpawnPosition { get; }
        private bool _isChasing;
        private Hero _hero;

        public override void Activate()
        {
            _hero = FindAnyObjectByType<Hero>();
            _isChasing = true;
        }

        private void Update()
        {
            if (_isChasing)
            {
                transform.position = Vector3.MoveTowards(transform.position, _hero.transform.position, speed * Time.deltaTime);
                animator.Play("Chase");
            }
            
        }
    }
}