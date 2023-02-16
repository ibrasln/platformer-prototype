using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Player
{
    public class PlayerLedgeGrabState : PlayerTouchingWallState
    {
        private Vector2 startPos;
        private Vector2 cornerPos;

        public PlayerLedgeGrabState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            player.SetVelocityZero();
            player.RB.gravityScale = 0;
            
            cornerPos = player.DetermineCornerPosition();
            startPos.Set(cornerPos.x - (player.FacingDirection * playerData.startOffset.x), cornerPos.y - playerData.startOffset.y);

            player.transform.position = startPos;

        }

        public override void Exit()
        {
            base.Exit();
            player.RB.gravityScale = 4;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (yInput == -1)
            {
                stateMachine.ChangeState(player.WallSlideState);
            }
            
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}