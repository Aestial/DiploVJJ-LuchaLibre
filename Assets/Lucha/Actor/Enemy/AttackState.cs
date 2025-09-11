using Lucha.Actor;
using UnityEngine;

namespace Lucha.Enemy
{
    public class AttackState : IActorState
    {
        public void EnterState(Actor.Actor actor) { /* Setup attack */ }

        public void UpdateState(Actor.Actor actor)
        {
            var enemy = actor as BasicEnemy;
            if (!enemy) return;

            var distanceToPlayer = Vector3.Distance(actor.transform.position, enemy.player.position);
            if (distanceToPlayer > enemy.attackRange)
            {
                enemy.ChangeState(typeof(ChaseState));
            }
        }

        public void ExitState(Actor.Actor actor) { /* Clean up */ }
    }
}