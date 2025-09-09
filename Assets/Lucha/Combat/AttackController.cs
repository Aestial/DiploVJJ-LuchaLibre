using Lucha.Actor;
using UnityEngine;
namespace Lucha.Combat
{
    public class AttackController : MonoBehaviour
    {
		private IAttackStrategy _currentAttack;

		public void SetAttackStrategy(IAttackStrategy attackStrategy)
		{
			_currentAttack = attackStrategy;
	    }

		public void PerformAttack(PlayerCharacter player)
		{
			_currentAttack?.ExecuteAttack(player);
		}
	}
}