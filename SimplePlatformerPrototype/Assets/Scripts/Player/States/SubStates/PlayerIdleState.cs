namespace Platformer.Player
{
    public class PlayerIdleState : PlayerGroundedState
    {
        public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            player.SetVelocityX(0f);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (xInput != 0)
                stateMachine.ChangeState(player.MoveState);
            // TODO: Add an else if for Crouch State
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
