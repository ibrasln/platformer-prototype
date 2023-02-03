using UnityEngine;

namespace Platformer.Attack
{
    [RequireComponent(typeof(MeleeAttackEvent))]
    [DisallowMultipleComponent]
    public class MeleeAttack : MonoBehaviour
    {
        private MeleeAttackEvent meleeAttackEvent;

        private void Awake()
        {
            meleeAttackEvent = GetComponent<MeleeAttackEvent>();
        }

        private void OnEnable()
        {
            meleeAttackEvent.OnMeleeAttack += MeleeAttackEvent_OnMeleeAttack;
        }

        private void OnDisable()
        {
            meleeAttackEvent.OnMeleeAttack -= MeleeAttackEvent_OnMeleeAttack;
        }

        private void MeleeAttackEvent_OnMeleeAttack(MeleeAttackEvent meleeAttackEvent, MeleeAttackEventArgs meleeAttackEventArgs)
        {
            Attack(meleeAttackEventArgs.attackPosition, meleeAttackEventArgs.attackRadius, meleeAttackEventArgs.whatIsEnemy);
        }

        private void Attack(Vector3 attackPosition, float attackRadius, LayerMask whatIsEnemy)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPosition, attackRadius, whatIsEnemy);

            foreach (Collider2D enemy in enemies)
            {
                Debug.Log("Hit Enemy!");
            }
        }
    }
}
