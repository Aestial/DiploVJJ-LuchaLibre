using Lucha.Actor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Lucha.Input
{
    // Input Handler
    public class InputHandler : MonoBehaviour
    {
        private PlayerInput _input;
        private PlayerCharacter _player;
        private InputSystem_Actions _actions;
        
        private void Awake()
        {
            _input = GetComponent<PlayerInput>();
            _player = GetComponent<PlayerCharacter>();
            
            // Suitable for single player
            _actions = new InputSystem_Actions();
        }
        
        private void OnEnable()
        {
            _actions.Player.Enable();
            
            // _actions.Player.Move.performed += ctx => OnMove(ctx.ReadValue<Vector2>());
            // _actions.Player.Jump.performed += ctx => OnJump();
        }
        
        /*private void OnMove(Vector2 direction)
        {
            ICommand command = new MoveCommand(direction);
            command.Execute(_player);
        }
    
        private void OnJump()
        {
            ICommand command = new JumpCommand();
            command.Execute(_player);
        }*/
        
        private void OnMove(InputValue value)
        {
            var direction = value.Get<Vector2>().normalized;
            ICommand command = new MoveCommand(direction);
            command.Execute(_player);
        }
        
        private void OnJump()
        {
            ICommand command = new JumpCommand();
            command.Execute(_player);
        }
    }
}