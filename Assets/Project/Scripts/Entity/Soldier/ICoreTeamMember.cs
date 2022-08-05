using Armyio.InputSystem;

namespace Armyio.Entity
{
    public interface ICoreTeamMember
    {
        IMovementMode MovementMode { get; }
    }
}