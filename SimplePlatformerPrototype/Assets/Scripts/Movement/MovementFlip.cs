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
            movementByVelocityEvent.OnMovementByVelocity += MovementByVelocityEvent_OnMovementByVelocity;
        }

        private void OnDisable()
        {
            movementByVelocityEvent.OnMovementByVelocity -= MovementByVelocityEvent_OnMovementByVelocity;
        }

        private void MovementByVelocityEvent_OnMovementByVelocity(MovementByVelocityEvent movementByVelocityEvent, MovementByVelocityEventArgs movementByVelocityEventArgs)
        {
            Flip(movementByVelocityEventArgs.direction);
        }

        private void Flip(float direction)
        {
            if (direction >= .01f) transform.localScale = Vector2.one;
            else if (direction <= -.01f) transform.localScale = new(-1, 1);
        }

    }
}
