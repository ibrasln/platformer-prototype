using System;
using UnityEngine;

namespace Platformer.Movement
{
    public class MovementByForceEvent : MonoBehaviour
    {
        public event Action<MovementByForceEvent, MovementByForceEventArgs> OnMovementByForce;

        public void CallMovementByForceEvent(float force, Vector2 direction)
        {
            OnMovementByForce?.Invoke(this, new MovementByForceEventArgs { force = force, direction = direction });
        }
    }

    public class MovementByForceEventArgs : EventArgs
    {
        public float force;
        public Vector2 direction;
    }
}
