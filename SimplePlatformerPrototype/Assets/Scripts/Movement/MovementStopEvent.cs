using System;
using UnityEngine;

namespace Platformer.Movement
{
    public class MovementStopEvent : MonoBehaviour
    {
        public event Action<MovementStopEvent> OnMovementStop;

        public void CallMovementStopEvent()
        {
            OnMovementStop?.Invoke(this);
        }
    }
}
