namespace Platformer.Player
{
    public class PlayerJumpState : PlayerAbilityState
    {
        public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.InputHandler.UseJumpInput();
            player.SetVelocityY(playerData.jumpPower);
            player.JumpAmountLeft--;
            isAbilityDone = true;
        }
    }
}
