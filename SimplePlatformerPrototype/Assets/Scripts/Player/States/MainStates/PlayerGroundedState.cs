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
        #endregion

        public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
            jumpInput = player.InputHandler.JumpInput;
            dashInput = player.InputHandler.DashInput;

            if (jumpInput)
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else if (dashInput && player.dashCooldownTimer <= 0)
            {
                player.InputHandler.UseDashInput();
                stateMachine.ChangeState(player.DashState);
            }
            else if (!onGround)
                stateMachine.ChangeState(player.InAirState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
