using UnityEngine;

namespace Platformer.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/Player Data")]
    public class PlayerDataSO : ScriptableObject
    {
        [Header("MOVEMENT")]
        public float moveSpeed = 10f;
    }
}
