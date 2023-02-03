using UnityEngine;

namespace Platformer.Player
{
    using Movement;
    using Attack;

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    [RequireComponent(typeof(MovementByForce))]
    [RequireComponent(typeof(MovementByForceEvent))]
    [RequireComponent(typeof(MovementByVelocity))]
    [RequireComponent(typeof(MovementByVelocityEvent))]
    [RequireComponent(typeof(MovementToPosition))]
    [RequireComponent(typeof(MovementToPositionEvent))]
    [RequireComponent(typeof(MovementStop))]
    [RequireComponent(typeof(MovementStopEvent))]
    [RequireComponent(typeof(MovementFlip))]
    [RequireComponent(typeof(MeleeAttack))]
    [RequireComponent(typeof(MeleeAttackEvent))]
    [DisallowMultipleComponent]
    public class Player : MonoBehaviour
    {
        [HideInInspector] public CapsuleCollider2D col;
        [HideInInspector] public MovementByForceEvent movementByForceEvent;
        [HideInInspector] public MovementByVelocityEvent movementByVelocityEvent;
        [HideInInspector] public MovementToPositionEvent movementToPositionEvent;
        [HideInInspector] public MovementStopEvent movementStopEvent;
        [HideInInspector] public MeleeAttackEvent meleeAttackEvent;

        private void Awake()
        {
            col = GetComponent<CapsuleCollider2D>();
            movementByForceEvent = GetComponent<MovementByForceEvent>();
            movementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
            movementToPositionEvent = GetComponent<MovementToPositionEvent>();
            movementStopEvent = GetComponent<MovementStopEvent>();
            meleeAttackEvent = GetComponent<MeleeAttackEvent>();
        }
    }
}
