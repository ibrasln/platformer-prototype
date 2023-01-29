using System;
using UnityEngine;

namespace Platformer.Movement
{
    public class MovementToPositionEvent : MonoBehaviour
    {
        public event Action<MovementToPositionEvent, MovementToPositionEventArgs> OnMovementToPosition;
        
        public void CallMovementToPositionEvent(Vector3 currentPosition, Vector3 targetPosition, float movementSpeed)
        {
            OnMovementToPosition?.Invoke(this, new MovementToPositionEventArgs { currentPosition = currentPosition, targetPosition = targetPosition, movementSpeed = movementSpeed });
        }
    }

    public class MovementToPositionEventArgs : EventArgs
    {
        public Vector3 currentPosition;
        public Vector3 targetPosition;
        public float movementSpeed;
    }
}
