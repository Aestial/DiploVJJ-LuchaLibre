using Lucha.Actor;

namespace Lucha.Input
{
    // Input Command Interface
    public interface ICommand
    {
        void Execute(PlayerCharacter player);
    }
}