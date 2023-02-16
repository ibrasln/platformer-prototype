using UnityEngine;

namespace Platformer.Player
{
    public class PlayerInAirState : PlayerState
    {
        #region Inputs
        protected int xInput;
        protected bool jumpInput;
        protected bool dashInput;
        #endregion

        #region Checks
        private bool onGround;
        private bool isTouchingWall;
        private bool canGrab;
        #endregion

        #region Other Variables
        private bool coyoteTime;
        #endregion

        public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
            onGround = player.CheckOnGround();
            isTouchingWall = player.CheckIsTouchingWall();
            canGrab = player.CheckCanGrab();
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            CheckCoyoteTime();

            player.Anim.SetFloat("yVelocity", player.RB.velocity.y);
            xInput = player.InputHandler.NormInputX;
            jumpInput = player.InputHandler.JumpInput;
            dashInput = player.InputHandler.DashInput;

            if (onGround && player.CurrentVelocity.y < .1f)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if (jumpInput && player.JumpState.CanJump())
            {   
                stateMachine.ChangeState(player.JumpState);
            }
            else if (dashInput && player.DashState.CanDash())
            {
                stateMachine.ChangeState(player.DashState);
            }
            else if (canGrab)
            {
                stateMachine.ChangeState(player.LedgeGrabState);
            }
            else if (isTouchingWall && (player.CurrentVelocity.y < .1f))
            {
                stateMachine.ChangeState(player.WallSlideState);
            }
            else
            {
                player.CheckIfShouldFlip(xInput);
                player.SetVelocityX(playerData.moveSpeedInAir * xInput);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        private void CheckCoyoteTime()
        {
            if (coyoteTime && Time.time >= startTime + playerData.coyoteTime)
            {
                coyoteTime = false;
                player.JumpState.DecreaseJumpAmountLeft();
            }
        }

        public void StartCoyoteTime() => coyoteTime = true;
    }
}
