namespace Lucha.Actor
{
    public class IdleState : ActorState
    {
        public override void EnterState(Actor actor)
        {
            // Reset movement or prepare for idle
        }

        public override void UpdateState(Actor actor)
        {
            // Check for transition conditions
            var player = actor as PlayerCharacter;
            if (player && player.MoveInput.magnitude > 0.1f)
            {
                player.ChangeState(typeof(MoveState));
            }
        }

        public override void ExitState(Actor actor)
        {
            // Clean up if needed
        }
    }
}