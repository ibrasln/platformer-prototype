using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Player
{
    public class PlayerDashState : PlayerAbilityState
    {
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
            player.SetVelocityX(playerData.dashSpeed);
        }

        public override void Exit()
        {
            base.Exit();
            player.dashCooldownTimer = playerData.dashCooldown;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
