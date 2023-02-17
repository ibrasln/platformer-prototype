using UnityEngine;

namespace Platformer.Player
{
    public class PlayerGroundedState : PlayerState
    {
        #region Inputs
        protected int xInput;
        protected int yInput;
        protected bool jumpInput;
        protected bool dashInput;
        #endregion

        #region Checks
        protected bool onGround;
        protected bool isTouchingWall;
        protected bool isTouchingLadder;
        #endregion

        public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
            onGround = player.CheckOnGround();
            isTouchingWall = player.CheckIsTouchingWall();
            // TODO: isTouchingLadder
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

            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
            jumpInput = player.InputHandler.JumpInput;
            dashInput = player.InputHandler.DashInput;

            if (jumpInput && player.JumpState.CanJump())
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else if (!onGround)
            {
                player.InAirState.StartCoyoteTime();
                stateMachine.ChangeState(player.InAirState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
