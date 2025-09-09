using Lucha.Actor;

namespace Lucha.Combat
{
    public interface IAttackStrategy
    {
        void ExecuteAttack(PlayerCharacter player);
    }
}