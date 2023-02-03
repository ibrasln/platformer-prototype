using System;
using UnityEngine;

namespace Platformer.Attack
{
    [DisallowMultipleComponent]
    public class MeleeAttackEvent : MonoBehaviour
    {
        public event Action<MeleeAttackEvent, MeleeAttackEventArgs> OnMeleeAttack;    
        
        public void CallMeleeAttackEvent(Vector3 attackPosition, float attackRadius, LayerMask whatIsEnemy)
        {
            OnMeleeAttack?.Invoke(this, new MeleeAttackEventArgs { attackPosition = attackPosition, attackRadius = attackRadius, whatIsEnemy = whatIsEnemy});
        }
    }

    public class MeleeAttackEventArgs : EventArgs
    {
        public Vector3 attackPosition;
        public float attackRadius;
        public LayerMask whatIsEnemy;
    }
}
