using UnityEngine.InputSystem;
using UnityEngine;

namespace Platformer.Player
{

    using Misc;

    [RequireComponent(typeof(Player))]
    [DisallowMultipleComponent]
    public class PlayerController : MonoBehaviour
    {
        #region Components
        private Player player;
        private Rigidbody2D rb;
        private Animator anim;
        #endregion

        #region Header MOVEMENT
        [Space(5)]
        [Header("MOVEMENT")]
        #endregion
        [SerializeField] private float runSpeed = 10f;
        private Vector2 moveInput;

        #region Header JUMP
        [Space(10)]
        [Header("JUMP")]
        #endregion
        [SerializeField] private float jumpForce;
        [SerializeField] private int jumpAmount = 2;
        private int jumpAmountLeft;

        #region CHECK GROUND
        [Space(3)]
        [Header("CHECK GROUND")]
        #endregion
        [SerializeField] private Transform groundCheckPosition;
        [SerializeField] private float groundCheckRadius;
        [SerializeField] private LayerMask whatIsGround;
        private bool onGround;

        private void Awake()
        {
            player = GetComponent<Player>();
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        #region INPUT
        private void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
        }

        private void OnJump(InputValue value)
        {
            if(value.isPressed)
            {
                Jump();
            }
        }
        #endregion

        private void Update()
        {
            UpdateAnimations();
            CheckSurroundings();
            CheckIfCanJump();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void UpdateAnimations()
        {
            anim.SetBool(Settings.onGround, onGround);
            anim.SetFloat(Settings.xVelocity, Mathf.Abs(rb.velocity.x));
            anim.SetFloat(Settings.yVelocity, rb.velocity.y);
        }

        private void CheckSurroundings()
        {
            onGround = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, whatIsGround);
        }

        private void Movement()
        {
            if (moveInput.x != 0)
                player.movementByVelocityEvent.CallMovementByVelocityEvent(runSpeed, moveInput.x);
            else
                player.movementStopEvent.CallMovementStopEvent();
        }

        private void Jump()
        {
            if (jumpAmountLeft > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpAmountLeft--;
            }
        }

        private void CheckIfCanJump()
        {
            if (onGround && rb.velocity.y <= .1f)
                jumpAmountLeft = jumpAmount;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheckPosition.position, groundCheckRadius);
        }
    }
}
