using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer.Player
{
    [RequireComponent(typeof(Player))]
    [DisallowMultipleComponent]
    public class PlayerController : MonoBehaviour
    {
        private Player player;

        private Vector2 moveInput;
        [SerializeField] private float movementSpeed = 10f;

        private bool onGround;
        [SerializeField] private Transform groundCheckPosition;
        [SerializeField] private float groundCheckRadius;
        [SerializeField] private LayerMask whatIsGround;

        [SerializeField] private float jumpForce = 16f;
        [SerializeField] private int jumpAmount = 2;
        private int jumpAmountLeft;

        private bool isDisabled;

        private void Awake()
        {
            player = GetComponent<Player>();
        }

        #region Input
        private void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
        }

        private void OnJump(InputValue value)
        {
            if (value.isPressed && jumpAmountLeft > 0)
            {
                player.movementByForceEvent.CallMovementByForceEvent(jumpForce, Vector2.up);
                jumpAmountLeft--;
            }
            else
                jumpAmountLeft = jumpAmount;
        }
        #endregion

        private void Update()
        {
            UpdateAnimations();
            if (isDisabled) return;
            CheckGround();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            if (moveInput.x != 0)
                player.movementByVelocityEvent.CallMovementByVelocityEvent(movementSpeed, moveInput.x);
            else
                player.movementStopEvent.CallMovementStopEvent();
        }

        private void UpdateAnimations()
        {
            player.anim.SetBool("onGround", onGround);
            player.anim.SetFloat("yVelocity", player.rB.velocity.y);
            player.anim.SetFloat("xVelocity", Mathf.Abs(player.rB.velocity.x));
        }

        private void CheckGround()
        {
            onGround = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, whatIsGround);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheckPosition.position, groundCheckRadius);
        }

        #region Disable & Enable
        public void DisablePlayer()
        {
            isDisabled = true;
            player.movementStopEvent.CallMovementStopEvent();
        }

        public void EnablePlayer()
        {
            isDisabled = false;
        }
        #endregion
    }
}
