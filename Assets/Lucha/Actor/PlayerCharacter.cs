using UnityEngine;

namespace Lucha.Actor
{
	public class PlayerCharacter : Actor
	{
		[SerializeField] private float moveSpeed = 5f;
		[SerializeField] private float jumpForce = 5f;
		
		public Vector2 MoveInput { get; private set; }
		
		private Collider _collider;

		protected override void Awake()
		{
			base.Awake();
			_collider = GetComponent<Collider>();
			// Additional player-specific initialization
		}

		public void Move(Vector2 direction)
		{
			MoveInput = direction;
			if (CurrentState is not MoveState) return;
			var moveDirection = new Vector3(direction.x, 0, direction.y);
			Rigidbody.AddForce(moveDirection *  moveSpeed, ForceMode.Force);
			
			// Simple rotation toward movement direction
			if (!(moveDirection.magnitude > 0.1f)) return;
			var targetRotation = Quaternion.LookRotation(moveDirection);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
		}

		public void Jump()
		{
			if (IsGrounded())
			{
				Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			}
		}

		private bool IsGrounded()
		{
			const float rayLength = 0.1f;
			return Physics.Raycast(transform.position, 
				Vector3.down, 
				_collider.bounds.extents.y + rayLength);
		}
		
		protected override void Die()
		{
			// Handle player death
			Debug.Log("Player died!");
			// Implement respawn or game over logic.
		}
	}
}