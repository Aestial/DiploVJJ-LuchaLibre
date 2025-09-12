namespace Lucha.Actor
{
    public abstract class ActorState : IActorState
    {
        public override string ToString()
        {
            return GetType().Name;
        }
        public virtual void EnterState(Actor actor)
        {}

        public virtual void UpdateState(Actor actor)
        {}

        public virtual void ExitState(Actor actor)
        {}
    }
}