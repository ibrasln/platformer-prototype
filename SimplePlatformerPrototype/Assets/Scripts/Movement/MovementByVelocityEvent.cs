using System;
using UnityEngine;

namespace Platformer.Movement
{
    public class MovementByVelocityEvent : MonoBehaviour
    {
        public event Action<MovementByVelocityEvent, MovementByVelocityEventArgs> OnMovementByVelocity;

        public void CallMovementByVelocity(float movementSpeed, Vector2 direction)
        {
            OnMovementByVelocity?.Invoke(this, new MovementByVelocityEventArgs { movementSpeed = movementSpeed , direction = direction });
        }
    }

    public class MovementByVelocityEventArgs : EventArgs
    {
        public float movementSpeed;
        public Vector2 direction;
    }
}
