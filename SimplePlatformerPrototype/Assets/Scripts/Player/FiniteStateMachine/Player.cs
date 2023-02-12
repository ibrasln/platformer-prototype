using UnityEngine;

namespace Platformer.Player
{
    public class Player : MonoBehaviour
    {
        #region STATES
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerCrouchState CrouchState { get; private set; }
        public PlayerSlideState SlideState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerDashState DashState { get; private set; }
        #endregion

        #region COMPONENTS
        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public Animator Anim { get; private set; }
        public Rigidbody2D RB { get; private set; }

        public PlayerDataSO playerData;
        #endregion

        #region OTHER VARIABLES
        public Vector2 CurrentVelocity { get; private set; }
        public int FacingDirection { get; private set; }
        public int JumpAmountLeft { get; set; }
        
        [HideInInspector] public float slideCooldownTimer;
        
        [HideInInspector] public float dashCooldownTimer;
        
        private Vector2 workspace;
        #endregion

        #region CHECK VARIABLES
        [SerializeField] private Transform groundCheckPosition;
        #endregion

        #region UNITY CALLBACK FUNCTIONS
        private void Awake()
        {
            StateMachine = new();
            InputHandler = GetComponent<PlayerInputHandler>();
            Anim = GetComponent<Animator>();
            RB = GetComponent<Rigidbody2D>();

            IdleState = new(this, StateMachine, playerData, "idle");
            MoveState = new(this, StateMachine, playerData, "move");
            CrouchState = new(this, StateMachine, playerData, "crouch");
            SlideState = new(this, StateMachine, playerData, "slide");
            JumpState = new(this, StateMachine, playerData, "inAir");
            InAirState = new(this, StateMachine, playerData, "inAir");
            DashState = new(this, StateMachine, playerData, "dash");
        }

        private void Start()
        {
            StateMachine.Initialize(IdleState);
            FacingDirection = 1;
            JumpAmountLeft = playerData.jumpAmount;
            slideCooldownTimer = playerData.slideCooldown;
            dashCooldownTimer = playerData.dashCooldown;
        }

        private void Update()
        {
            CurrentVelocity = RB.velocity;
            StateMachine.CurrentState.LogicUpdate();

            ReduceCooldownTimer(ref slideCooldownTimer);
            ReduceCooldownTimer(ref dashCooldownTimer);
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }
        #endregion

        #region SET FUNCTIONS
        public void SetVelocityX(float xVelocity)
        {
            workspace.Set(xVelocity, RB.velocity.y);
            RB.velocity = workspace;
        }

        public void SetVelocityY(float yVelocity)
        {
            workspace.Set(RB.velocity.x, yVelocity);
            RB.velocity = workspace;
        }
        #endregion

        #region CHECK FUNCTIONS
        public bool CheckOnGround()
        {
            return Physics2D.OverlapCircle(groundCheckPosition.position, playerData.groundCheckRadius, playerData.whatIsGround);
        }

        public void CheckIfShouldFlip(int xInput)
        {
            if (xInput != 0 && xInput != FacingDirection)
                Flip();
        }
        #endregion

        #region OTHER FUNCTIONS
        private void Flip()
        {
            FacingDirection *= -1;
            transform.Rotate(0.0f, 180.0f, 0f);
        }

        private void ReduceCooldownTimer(ref float cooldownTimer)
        {
            if (cooldownTimer > 0)
                cooldownTimer -= Time.deltaTime;
        }
        #endregion

        #region Gizmos
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheckPosition.position, playerData.groundCheckRadius);
        }
        #endregion
    }
}
