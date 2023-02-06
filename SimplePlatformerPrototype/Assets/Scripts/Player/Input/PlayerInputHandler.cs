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

        public void OnMove(InputValue value)
        {
            RawMovementInput = value.Get<Vector2>();
            NormInputX = (int)RawMovementInput.normalized.x;
            NormInputY = (int)RawMovementInput.normalized.y;
        }

        public void OnJump(InputValue value)
        {
            if(value.isPressed)
            {
                JumpInput = true;
                Debug.Log("Jump button was pressed");
            }
        }
    }
}
