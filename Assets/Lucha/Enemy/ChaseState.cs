using Lucha.Actor;
using UnityEngine;

namespace Lucha.Enemy
{
    public class ChaseState : IActorState
    {
        private Rigidbody _rigidbody;
        
        public void EnterState(Actor.Actor actor)
        {
            _rigidbody = actor.GetComponent<Rigidbody>();
             /* Setup chase */
        }

        public void UpdateState(Actor.Actor actor)
        {
            var enemy = actor as BasicEnemy;
            if (!enemy) return;
        
            var direction = (enemy.player.position - actor.transform.position).normalized;
            _rigidbody.AddForce(direction * enemy.moveSpeed, ForceMode.Force);
            
            var distanceToPlayer = Vector3.Distance(actor.transform.position, enemy.player.position);
            if (distanceToPlayer < enemy.detectionRange)
            {
                enemy.ChangeState(typeof(AttackState));
            }
        }

        public void ExitState(Actor.Actor actor) { /* Clean up */ }
    }
}