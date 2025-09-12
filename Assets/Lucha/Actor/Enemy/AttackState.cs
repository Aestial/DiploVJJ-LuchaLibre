using UnityEngine;

namespace Lucha.Actor.Enemy
{
    public class AttackState : ActorState
    {
        public override void EnterState(Actor actor) { /* Setup attack */ }

        public override void UpdateState(Actor actor)
        {
            var enemy = actor as BasicEnemy;
            if (!enemy) return;

            var distanceToPlayer = Vector3.Distance(actor.transform.position, enemy.player.position);
            if (distanceToPlayer > enemy.attackRange)
            {
                enemy.ChangeState(typeof(ChaseState));
            }
        }

        public override void ExitState(Actor actor) { /* Clean up */ }
    }
}