using Lucha.Actor;

namespace Lucha.Input
{
    public class JumpCommand : ICommand
	{
	    public void Execute(PlayerCharacter player)
	    {
        	player.Jump();
    	}
	}
}