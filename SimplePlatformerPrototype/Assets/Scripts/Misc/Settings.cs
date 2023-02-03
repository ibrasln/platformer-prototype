using UnityEngine;

namespace Platformer.Misc
{
    public static class Settings
    {
        #region ANIMATION
        // PLAYER
        public static int onGround = Animator.StringToHash("onGround");
        public static int xVelocity = Animator.StringToHash("xVelocity");
        public static int yVelocity = Animator.StringToHash("yVelocity");
        public static int isCrouching = Animator.StringToHash("isCrouching");
        public static int isAttacking = Animator.StringToHash("isAttacking");
        #endregion
    }
}
