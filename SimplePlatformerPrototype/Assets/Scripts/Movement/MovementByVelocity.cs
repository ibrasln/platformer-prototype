using UnityEngine;

namespace Platformer.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(MovementByVelocityEvent))]
    [DisallowMultipleComponent]
    public class MovementByVelocity : MonoBehaviour
    {
        private Rigidbody2D rb;
        private MovementByVelocityEvent movementByVelocityEvent;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            movementByVelocityEvent= GetComponent<MovementByVelocityEvent>();
        }

        private void OnEnable()
        {
            movementByVelocityEvent.OnMovementByVelocity += MovementByVelocityEvent_OnMovementByVelocity;
        }

        private void OnDisable()
        {
            movementByVelocityEvent.OnMovementByVelocity -= MovementByVelocityEvent_OnMovementByVelocity;
        }

        private void MovementByVelocityEvent_OnMovementByVelocity(MovementByVelocityEvent movementByVelocityEvent, MovementByVelocityEventArgs movementByVelocityEventArgs)
        {
            MoveRigidbody(movementByVelocityEventArgs.movementSpeed, movementByVelocityEventArgs.direction);
        }

        private void MoveRigidbody(float movementSpeed, float direction)
        {
            rb.velocity = new(movementSpeed * direction, rb.velocity.y);
        }
    }
}
