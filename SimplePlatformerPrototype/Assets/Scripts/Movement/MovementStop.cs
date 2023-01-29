using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(MovementStopEvent))]
    [DisallowMultipleComponent]
    public class MovementStop : MonoBehaviour
    {
        private Rigidbody2D rb;
        private MovementStopEvent movementStopEvent;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            movementStopEvent = GetComponent<MovementStopEvent>();
        }

        private void OnEnable()
        {
            movementStopEvent.OnMovementStop += MovementStopEvent_OnMovementStop;
        }

        private void OnDisable()
        {
            movementStopEvent.OnMovementStop -= MovementStopEvent_OnMovementStop;
        }

        private void MovementStopEvent_OnMovementStop(MovementStopEvent movementStopEvent)
        {
            StopRigidbody();
        }

        private void StopRigidbody()
        {
            rb.velocity = new(0f, rb.velocity.y);
        }
    }
}
