using System.Collections.Generic;
using UnityEngine;

namespace Lucha.Actor
{
    public abstract class Actor : MonoBehaviour
    {
        [SerializeField] protected float maxHealth = 100f;
        protected float CurrentHealth;
        protected IActorState CurrentState;

        protected Rigidbody Rigidbody;
        protected Collider Collider;

        protected readonly Dictionary<System.Type, IActorState> States = new();

        protected virtual void Awake()
        {
            CurrentHealth = maxHealth;
            Rigidbody = GetComponent<Rigidbody>();
            Collider = GetComponent<Collider>();
        
            // Initialize states
            States.Add(typeof(IdleState), new IdleState());
            States.Add(typeof(MoveState), new MoveState());

            ChangeState(typeof(IdleState));
        }

        public void ChangeState(System.Type newStateType)
        {
            if (!States.ContainsKey(newStateType)) return;
            CurrentState?.ExitState(this);
            CurrentState = States[newStateType];
            CurrentState.EnterState(this);
        }

        protected virtual void FixedUpdate()
        {
            CurrentState?.UpdateState(this);
        }

        public virtual void ReceiveDamage(DamageData damageData)
        {
            CurrentHealth -= damageData.Amount;
            
            // Apply knockback
            if (Rigidbody == null) return;
            var direction = (transform.position - damageData.Source.transform.position).normalized;
            Rigidbody.AddForce(direction * damageData.KnockbackForce, ForceMode.Impulse);

            if (CurrentHealth <= 0)
                Die();
        }

        protected abstract void Die();
    }
}