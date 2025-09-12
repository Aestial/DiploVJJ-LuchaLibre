using UnityEngine;

namespace Lucha.Actor.Enemy
{
    public class BasicEnemy : Actor
    {
        public float detectionRange = 5f;
        public float attackRange = 1.5f;
        public float moveSpeed = 3f;

        //[HideInInspector]
        public Transform player;

        protected override void Awake()
        {
            base.Awake();
            player = GameObject.FindWithTag("Player").transform;
            
            if (player == null)
                Debug.LogError("Player not found");
            
            // Add enemy-specific states
            States.Add(typeof(PatrolState), new PatrolState());
            States.Add(typeof(ChaseState), new ChaseState());
            States.Add(typeof(AttackState), new AttackState());
        }

        private void Start()
        {
            ChangeState(typeof(PatrolState));
        }

        protected override void Die()
        {
            // Handle enemy death
            Debug.Log("Enemy defeated!");
            Destroy(gameObject);
        }
    }
}