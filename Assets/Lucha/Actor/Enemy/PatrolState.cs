using UnityEngine;

namespace Lucha.Actor.Enemy
{
    public class PatrolState : ActorState
    {
        public override void EnterState(Actor actor) { /* Setup patrol */ }

        public override void UpdateState(Actor actor)
        {
            var enemy = actor as BasicEnemy;
            if (!enemy) return;
            
            var distanceToPlayer = Vector3.Distance(actor.transform.position, enemy.player.position);
            if (distanceToPlayer < enemy.detectionRange)
            {
                enemy.ChangeState(typeof(ChaseState));
            }
                
            // Implement patrol logic
        }

        public override void ExitState(Actor actor) { /* Clean up */ }
    }
}