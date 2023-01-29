using UnityEngine;

namespace Platformer.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(MovementToPositionEvent))]
    [DisallowMultipleComponent]
    public class MovementToPosition : MonoBehaviour
    {
        private Rigidbody2D rB;
        private MovementToPositionEvent movementToPositionEvent;

        private void Awake()
        {
            rB = GetComponent<Rigidbody2D>();
            movementToPositionEvent = GetComponent<MovementToPositionEvent>();
        }

        private void OnEnable()
        {
            movementToPositionEvent.OnMovementToPosition += MovementToPositionEvent_OnMovementToPosition;
        }

        private void OnDisable()
        {
            movementToPositionEvent.OnMovementToPosition -= MovementToPositionEvent_OnMovementToPosition;
        }

        private void MovementToPositionEvent_OnMovementToPosition(MovementToPositionEvent movementToPositionEvent, MovementToPositionEventArgs movementToPositionEventArgs)
        {
            MovePosition(movementToPositionEventArgs.currentPosition, movementToPositionEventArgs.targetPosition, movementToPositionEventArgs.movementSpeed);
        }

        private void MovePosition(Vector3 currentPosition, Vector3 targetPosition, float movementSpeed)
        {
            Vector2 unitVector = Vector3.Normalize(targetPosition - currentPosition);
            rB.MovePosition(rB.position + unitVector * movementSpeed * Time.fixedDeltaTime);
        }
    }
}
