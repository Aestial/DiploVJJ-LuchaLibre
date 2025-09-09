using Lucha.Actor;
using UnityEngine;

namespace Lucha.Combat
{
    public class PunchAttack : IAttackStrategy
    {
        public void ExecuteAttack(PlayerCharacter player)
        {
            // Implement punch logic
            Debug.Log("Punch attack!");
        }
    }
}