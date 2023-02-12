using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 RawMovementInput { get; private set; }
        public int NormInputX { get; private set; }
        public int NormInputY { get; private set; }
        public bool JumpInput { get; private set; }
        public bool DashInput { get; private set; }

        public void OnMove(InputValue value)
        {
            RawMovementInput = value.Get<Vector2>();
            NormInputX = Mathf.RoundToInt(RawMovementInput.normalized.x);
            NormInputY = Mathf.RoundToInt(RawMovementInput.normalized.y);
        }

        public void OnJump(InputValue value)
        {
            if(value.isPressed)
            {
                JumpInput = true;
            }
        }

        public void OnDash(InputValue value)
        {
            if(value.isPressed)
            {
                DashInput = true;
            }
        }

        public void UseJumpInput() => JumpInput = false;
        public void UseDashInput() => DashInput = false;
    }
}
