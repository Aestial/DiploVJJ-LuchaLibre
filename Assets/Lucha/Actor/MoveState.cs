namespace Lucha.Actor
{
    public class MoveState : IActorState
    {
        public void EnterState(Lucha.Actor.Actor actor)
        {
            // Prepare for movement
        }

        public void UpdateState(Lucha.Actor.Actor actor)
        {
            var player = actor as PlayerCharacter;
            if (!player) return;
            
            player.Move(player.MoveInput);

            if (player.MoveInput.magnitude < 0.1f)
            {
                player.ChangeState(typeof(IdleState));
            }
        }

        public void ExitState(Lucha.Actor.Actor actor)
        {
            // Clean up if needed
        }
    }
}