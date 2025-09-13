namespace Lucha.Actor
{
    public class DeadState : IActorState
    {
        public void EnterState(Actor actor)
        {
            // Reset movement or prepare for idle
        }

        public void UpdateState(Actor actor)
        {
            // Check for transition conditions
            // Timeout and destroy
        }

        public void ExitState(Actor actor)
        {
            // Clean up if needed
        }
    }
}