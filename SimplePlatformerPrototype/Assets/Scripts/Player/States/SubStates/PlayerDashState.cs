using UnityEngine;

namespace Platformer.Player
{
    public class PlayerDashState : PlayerAbilityState
    {
        private float lastDashTime;
        private Vector2 lastAIPos;

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
            if (Time.time >= startTime + playerData.dashTime || isTouchingWall)
            {
                isAbilityDone = true;
                lastDashTime = Time.time;
            }
            else
            {
                player.SetVelocityX(playerData.dashSpeed * player.FacingDirection);
                player.SetVelocityY(0f);
                CheckIfShouldPlaceAfterImage();
            }
            
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        private void CheckIfShouldPlaceAfterImage()
        {
            if (Mathf.Abs(player.transform.position.x - lastAIPos.x) >= playerData.distanceBetweenAIs)
                PlaceAfterImage();
        }

        private void PlaceAfterImage()
        {
            PlayerAfterImagePool.instance.GetObjectFromPool();
            lastAIPos = player.transform.position;
        }

        public bool CanDash()
        {
            return Time.time >= lastDashTime + playerData.dashCooldown;
        }
    }
}
