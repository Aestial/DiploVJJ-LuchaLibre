namespace Lucha.Actor
{
    public class MoveState : IActorState
    {
        public void EnterState(Actor actor)
        {
            // Prepare for movement
        }

        public void UpdateState(Actor actor)
        {
            var player = actor as PlayerCharacter;
            if (!player) return;
            
            player.Move(player.MoveInput);

            if (player.MoveInput.magnitude < 0.1f)
            {
                player.ChangeState(typeof(IdleState));
            }
        }

        public void ExitState(Actor actor)
        {
            // Clean up if needed
        }
    }
}