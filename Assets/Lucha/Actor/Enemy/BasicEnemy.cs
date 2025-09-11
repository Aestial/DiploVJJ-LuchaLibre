using System;
using UnityEngine;

namespace Lucha.Enemy
{
    public class BasicEnemy : Actor.Actor
    {
        public float detectionRange = 5f;
        public float attackRange = 1.5f;
        public float moveSpeed = 3f;

        [HideInInspector]
        public Transform player;

        protected override void Awake()
        {
            base.Awake();
            player = GameObject.FindWithTag("Player").transform;
            
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