
using UnityEngine;

namespace Platformer.Player
{
    public class PlayerDashState : PlayerAbilityState
    {
        private float lastDashTime;
        public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            player.InputHandler.UseDashInput();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Time.time >= startTime + playerData.dashTime)
            {
                isAbilityDone = true;
                lastDashTime = Time.time;
            }
            else
            {
                player.SetVelocityX(playerData.dashSpeed * player.FacingDirection);
                player.SetVelocityY(0f);
            }
            
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public bool CanDash()
        {
            return Time.time >= lastDashTime + playerData.dashCooldown;
        }
    }
}
