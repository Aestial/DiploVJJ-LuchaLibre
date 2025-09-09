namespace Lucha.Actor
{
    // State Interface
    public interface IActorState
    {
        void EnterState(Lucha.Actor.Actor actor);
        void UpdateState(Lucha.Actor.Actor actor);
        void ExitState(Lucha.Actor.Actor actor);
    }
}