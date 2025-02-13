using _project.Scripts.Game.Entities;
using UnityEngine;

namespace _project.Scripts.Game.Obstacles
{
    public class Teacher : Obstacle
    {
        [SerializeField] private Animator animator;
        [SerializeField] private float speed;
        public override string ObstaclePath => Constants.Paths.TeacherPath;
        private bool _isChasing;
        private Hero _hero;
        private readonly int isChasing = Animator.StringToHash("isChasing");

        public override void Activate()
        {
            _hero = FindAnyObjectByType<Hero>();
            Appear();
            _isChasing = true;
        }

        private void Appear()
        {
            
        }

        private void Update()
        {
            if (_isChasing)
            {
                Chase();
                var distance = Vector3.Distance(transform.position, _hero.transform.position);
                if (distance > 20)
                {
                    _isChasing = false;
                    Destroy(gameObject);
                }
            }
            
        }

        private void Chase()
        {
            transform.position = Vector3.MoveTowards(transform.position, _hero.transform.position, speed * Time.deltaTime);
            transform.LookAt(_hero.transform);
            animator.SetBool(isChasing, true);
        }
    }
}