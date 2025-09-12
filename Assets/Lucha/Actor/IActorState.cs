namespace Lucha.Actor
{
    // State Interface
    public interface IActorState
    {
        void EnterState(Actor actor);
        void UpdateState(Actor actor);
        void ExitState(Actor actor);
    }
}