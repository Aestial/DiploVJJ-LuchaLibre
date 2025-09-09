using Lucha.Actor;
using UnityEngine;

namespace Lucha.Combat
{
    public class KickAttack : IAttackStrategy
    {
        public void ExecuteAttack(PlayerCharacter player)
        {
            // Implement kick logic
            Debug.Log("Kick attack!");
        }
    }
}