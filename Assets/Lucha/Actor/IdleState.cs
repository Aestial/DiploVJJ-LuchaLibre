namespace Lucha.Actor
{
    public class IdleState : IActorState
    {
        public void EnterState(Lucha.Actor.Actor actor)
        {
            // Reset movement or prepare for idle
        }

        public void UpdateState(Lucha.Actor.Actor actor)
        {
            // Check for transition conditions
            var player = actor as PlayerCharacter;
            if (player && player.MoveInput.magnitude > 0.1f)
            {
                player.ChangeState(typeof(MoveState));
            }
        }

        public void ExitState(Lucha.Actor.Actor actor)
        {
            // Clean up if needed
        }
    }
}