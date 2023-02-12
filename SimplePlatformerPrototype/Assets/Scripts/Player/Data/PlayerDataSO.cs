using UnityEngine;

namespace Platformer.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/Player Data")]
    public class PlayerDataSO : ScriptableObject
    {
        [Header("MOVEMENT")]
        public float moveSpeed = 12f;

        [Space(10)]
        [Header("JUMP")]
        public float jumpPower = 10f;
        public int jumpAmount = 2;

        [Space(10)]
        [Header("GROUND")]
        public float groundCheckRadius = .3f;
        public LayerMask whatIsGround;

        [Space(10)]
        [Header("SLIDE")]
        public float slideSpeed = 12f;
        public float slideCooldown = 1f;
        public float slideTime = .5f;

        [Space(10)]
        [Header("DASH")]
        public float dashSpeed = 15f;
        public float dashCooldown = 1f;
        public float dashTime = .6f;
    }
}
