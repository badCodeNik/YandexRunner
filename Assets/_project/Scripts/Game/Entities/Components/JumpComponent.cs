using System;
using UnityEngine;

namespace _project.Scripts.Game.Entities.Components
{
    [Serializable]
    public class JumpComponent
    {
        private readonly Rigidbody _rigidbody;
        private readonly GameObject _groundCheck;
        private readonly LayerMask _groundLayer;

        [SerializeField] private float jumpForce = 20f;
        [SerializeField] private float groundCheckDistance = 0.1f;
        [SerializeField] private float gravityMultiplier = 4f;

        private bool _isJumping;

        public JumpComponent(Rigidbody rigidbody, GameObject groundCheck)
        {
            _rigidbody = rigidbody;
            _groundCheck = groundCheck;

            _rigidbody.useGravity = true;
            _groundLayer = LayerMask.GetMask("Ground");
            Debug.Log(_groundLayer.ToString());
        }

        public void Jump()
        {
            if (_isJumping) return;

            _rigidbody.linearVelocity =
                new Vector3(_rigidbody.linearVelocity.x, jumpForce, _rigidbody.linearVelocity.z);
            _isJumping = true;
        }

        public void Update()
        {
            _isJumping = !IsGrounded();
            ApplyGravity();
            
        }

        public void ApplyGravity()
        {
            if (_isJumping)
            {
                _rigidbody.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
            }
        }

        public bool IsGrounded()
        {
            return Physics.Raycast(_groundCheck.transform.position, Vector3.down, groundCheckDistance, _groundLayer);
        }
    }
}