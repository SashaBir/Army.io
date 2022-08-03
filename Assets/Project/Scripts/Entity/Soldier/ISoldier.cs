using Armyio.Physics;

namespace Armyio.Entity
{
    public interface ISoldier
    {
        Movement Movement { get; }
        
        void Shoot();
    }
}