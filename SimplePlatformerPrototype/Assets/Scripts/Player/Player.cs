using UnityEngine;

namespace Platformer.Player
{
    using Movement;
    
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
    [DisallowMultipleComponent]
    public class Player : MonoBehaviour
    {
        [HideInInspector] public Rigidbody2D rB;
        [HideInInspector] public Animator anim;
        [HideInInspector] public CapsuleCollider2D col;
        [HideInInspector] public MovementByForceEvent movementByForceEvent;
        [HideInInspector] public MovementByVelocityEvent movementByVelocityEvent;
        [HideInInspector] public MovementToPositionEvent movementToPositionEvent;
        [HideInInspector] public MovementStopEvent movementStopEvent;

        private void Awake()
        {
            rB = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            col = GetComponent<CapsuleCollider2D>();
            movementByForceEvent = GetComponent<MovementByForceEvent>();
            movementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
            movementToPositionEvent = GetComponent<MovementToPositionEvent>();
            movementStopEvent = GetComponent<MovementStopEvent>();
        }
    }
}
