using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lucha.Actor
{
    public abstract class Actor : MonoBehaviour
    {
        public float maxHealth = 100f;
        public float CurrentHealth { get; private set; }
        
        public IActorState CurrentState;

        protected Rigidbody Rigidbody;
        protected Collider Collider;

        protected readonly Dictionary<Type, IActorState> States = new();
        
        // Events
        public event Action<Type> OnStateChanged;
        public event Action<float, float> OnHealthChanged; // current, max
        public event Action<string> OnActorDied;

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
            
            // Trigger event
            OnStateChanged?.Invoke(newStateType);
        }

        protected virtual void FixedUpdate()
        {
            CurrentState?.UpdateState(this);
        }

        public virtual void ReceiveDamage(DamageData damageData)
        {
            var previousHealth = CurrentHealth;
            CurrentHealth -= damageData.Amount;
            
            // Trigger health change event
            OnHealthChanged?.Invoke(CurrentHealth, maxHealth);
            
            // Apply knockback
            if (Rigidbody == null) return;
            var direction = (transform.position - damageData.Source.transform.position).normalized;
            Rigidbody.AddForce(direction * damageData.KnockbackForce, ForceMode.Impulse);

            if (CurrentHealth <= 0)
                Die();
        }

        protected virtual void Die()
        {
            OnActorDied?.Invoke(gameObject.name);
        }
        
    }
}