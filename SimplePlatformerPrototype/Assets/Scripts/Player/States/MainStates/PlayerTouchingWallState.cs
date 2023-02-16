using UnityEngine;

namespace Platformer.Player
{
    public class PlayerTouchingWallState : PlayerState
    {
        protected bool onGround;
        protected bool isTouchingWall;
        protected bool jumpInput;
        protected int xInput;
        protected int yInput;

        public PlayerTouchingWallState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();
        }

        public override void DoChecks()
        {
            base.DoChecks();
            onGround = player.CheckOnGround();
            isTouchingWall = player.CheckIsTouchingWall();
        }

        public override void Enter()
        {
            base.Enter();
            player.JumpState.ResetJumpAmountLeft();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            jumpInput = player.InputHandler.JumpInput;
            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;

            if (onGround && player.CurrentVelocity.y < .1f)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if (jumpInput && player.JumpState.CanJump() && (player.FacingDirection * -1) == xInput)
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else if (!isTouchingWall && player.CurrentVelocity.y < .1f)
            {
                stateMachine.ChangeState(player.InAirState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
