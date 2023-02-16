using UnityEngine;

namespace Platformer.Player
{
    public class PlayerSlideState : PlayerGroundedState
    {
        private float lastSlideTime;
        public PlayerSlideState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
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

            if (Time.time >= startTime + playerData.slideTime)
                stateMachine.ChangeState(player.IdleState);
            else
                player.SetVelocityX(playerData.slideSpeed * player.FacingDirection);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public bool CanSlide()
        {
            return Time.time >= lastSlideTime + playerData.slideCooldown;
        }
    }
}
