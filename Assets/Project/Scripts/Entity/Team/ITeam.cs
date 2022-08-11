using UnityEngine;

namespace Armyio.Entity
{
    public interface ITeam
    {
        Vector3 PositionCoreTeamMember { get; }
        
        void Add(Soldier soldier);
    }
}