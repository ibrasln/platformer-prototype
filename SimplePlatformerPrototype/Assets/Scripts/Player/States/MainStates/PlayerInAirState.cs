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
        protected bool onGround;
        #endregion

        public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
            onGround = player.CheckOnGround();
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
            player.Anim.SetFloat("yVelocity", player.RB.velocity.y);
            xInput = player.InputHandler.NormInputX;
            jumpInput = player.InputHandler.JumpInput;
            dashInput = player.InputHandler.DashInput;

            if (onGround && player.CurrentVelocity.y < .1f)
            {
                player.JumpAmountLeft = playerData.jumpAmount;
                stateMachine.ChangeState(player.IdleState);
            }
            else if (jumpInput && player.JumpAmountLeft > 0)
            {   
                stateMachine.ChangeState(player.JumpState);
            }
            else if (dashInput && player.dashCooldownTimer <= 0)
            {
                stateMachine.ChangeState(player.DashState);
            }
            else
            {
                player.CheckIfShouldFlip(xInput);
                player.SetVelocityX(playerData.moveSpeed * xInput);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
