using UnityEngine;

namespace Platformer.Player
{
    public class PlayerSlideState : PlayerGroundedState
    {
        private float lastSlideTime;
        private Vector2 lastAIPos;

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

            if (Time.time >= startTime + playerData.slideTime || isTouchingWall)
            { 
                stateMachine.ChangeState(player.IdleState);
            }
            else
            {
                player.SetVelocityX(playerData.slideSpeed * player.FacingDirection);
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

        public bool CanSlide()
        {
            return Time.time >= lastSlideTime + playerData.slideCooldown;
        }
    }
}
