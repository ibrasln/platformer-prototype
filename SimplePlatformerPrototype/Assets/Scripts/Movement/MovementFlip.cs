using UnityEngine;

namespace Platformer.Movement
{
    [RequireComponent(typeof(MovementByForceEvent))]
    [RequireComponent(typeof(MovementByVelocityEvent))]
    [DisallowMultipleComponent]
    public class MovementFlip : MonoBehaviour
    {
        private MovementByForceEvent movementByForceEvent;
        private MovementByVelocityEvent movementByVelocityEvent;

        private void Awake()
        {
            movementByForceEvent = GetComponent<MovementByForceEvent>();
            movementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
        }

        private void OnEnable()
        {
            movementByForceEvent.OnMovementByForce += MovementByForceEvent_OnMovementByForce; ;
            movementByVelocityEvent.OnMovementByVelocity += MovementByVelocityEvent_OnMovementByVelocity;
        }

        private void OnDisable()
        {
            movementByForceEvent.OnMovementByForce -= MovementByForceEvent_OnMovementByForce; ;
            movementByVelocityEvent.OnMovementByVelocity -= MovementByVelocityEvent_OnMovementByVelocity;
        }

        private void MovementByForceEvent_OnMovementByForce(MovementByForceEvent movementByForceEvent, MovementByForceEventArgs movementByForceEventArgs)
        {
            Flip(movementByForceEventArgs.direction);
        }
        private void MovementByVelocityEvent_OnMovementByVelocity(MovementByVelocityEvent movementByVelocityEvent, MovementByVelocityEventArgs movementByVelocityEventArgs)
        {
            Flip(movementByVelocityEventArgs.direction);
        }

        private void Flip(Vector2 direction)
        {
            if (direction.x >= .01f) transform.localScale = Vector2.one;
            else if (direction.x <= -.01f) transform.localScale = new(-1, 1);
        }

    }
}
