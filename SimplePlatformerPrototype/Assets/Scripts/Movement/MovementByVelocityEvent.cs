using System;
using UnityEngine;

namespace Platformer.Movement
{
    public class MovementByVelocityEvent : MonoBehaviour
    {
        public event Action<MovementByVelocityEvent, MovementByVelocityEventArgs> OnMovementByVelocity;

        public void CallMovementByVelocityEvent(float movementSpeed, float direction)
        {
            OnMovementByVelocity?.Invoke(this, new MovementByVelocityEventArgs { movementSpeed = movementSpeed , direction = direction });
        }
    }

    public class MovementByVelocityEventArgs : EventArgs
    {
        public float movementSpeed;
        public float direction;
    }
}
