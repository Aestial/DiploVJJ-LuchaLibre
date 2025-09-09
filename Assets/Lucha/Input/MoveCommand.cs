using Lucha.Actor;
using UnityEngine;

namespace Lucha.Input
{
    // Concrete Commands
	public class MoveCommand : ICommand
	{
    	private Vector2 _direction;
    
    	public MoveCommand(Vector2 direction)
    	{
	        _direction = direction;
	    }
    	
    	public void Execute(PlayerCharacter player)
    	{
	        player.Move(_direction);
	    }
	}
}