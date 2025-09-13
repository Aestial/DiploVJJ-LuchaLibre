using UnityEngine;

namespace Lucha.Actor.Enemy
{
    public class ChaseState : IActorState
    {
        private Rigidbody _rigidbody;
        
        public void EnterState(Actor actor)
        {
            _rigidbody = actor.GetComponent<Rigidbody>();
             /* Setup chase */
        }

        public void UpdateState(Actor actor)
        {
            var enemy = actor as BasicEnemy;
            if (!enemy) return;
        
            var direction = (enemy.player.position - actor.transform.position).normalized;
            _rigidbody.AddForce(direction * enemy.moveSpeed, ForceMode.Force);
            
            var distanceToPlayer = Vector3.Distance(actor.transform.position, enemy.player.position);
            if (distanceToPlayer <= enemy.attackRange)
            {
                enemy.ChangeState(typeof(AttackState));
            }
        }
        public void ExitState(Actor actor) { /* Clean up */ }
    }
}