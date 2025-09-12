namespace Lucha.Actor
{
    public class MoveState : ActorState
    {
        public override void EnterState(Actor actor)
        {
            // Prepare for movement
        }

        public override void UpdateState(Actor actor)
        {
            var player = actor as PlayerCharacter;
            if (!player) return;
            
            player.Move(player.MoveInput);

            if (player.MoveInput.magnitude < 0.1f)
            {
                player.ChangeState(typeof(IdleState));
            }
        }

        public override void ExitState(Actor actor)
        {
            // Clean up if needed
        }
    }
}